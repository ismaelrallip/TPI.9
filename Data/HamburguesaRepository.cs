using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HamburguesaRepository : IHamburguesaRepository
    {
        private readonly TPIContext context;

        public HamburguesaRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Hamburguesa>> GetAllAsync()
        {
            return await context.Hamburguesas
                            .Include(h => h.Precios)
                            .Include(h => h.Ingredientes)
                            .ToListAsync();
        }

        public async Task<Hamburguesa?> GetByIdAsync(int id)
        {
            return await context.Hamburguesas
                                .Include(h => h.Precios)
                                .Include(h => h.Ingredientes)
                                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<Hamburguesa>> GetByCriteriaAsync(string texto)
        {
            var query = context.Hamburguesas
                               .Include(h => h.Precios)
                               .Include(h => h.Ingredientes)
                               .AsQueryable();

            // El filtro se resuelve en la base de datos (WHERE ... LIKE), no en memoria
            if (!string.IsNullOrWhiteSpace(texto))
            {
                var buscado = texto.Trim();
                query = query.Where(h => h.Nombre.Contains(buscado) || h.Descripcion.Contains(buscado));
            }

            return await query.OrderBy(h => h.Nombre).ToListAsync();
        }

        public async Task AddAsync(Hamburguesa hamburguesa)
        {
            var ids = hamburguesa.Ingredientes?.Select(i => i.Id).Where(id => id > 0).ToList() ?? new List<int>();
            var ingredientesExistentes = await context.Ingredientes
                                              .Where(i => ids.Contains(i.Id))
                                              .ToListAsync();

            if (ingredientesExistentes.Count != ids.Count)
                throw new ArgumentException("Uno o más ingredientes no existen.");

            // Reemplazar la colección por las entidades rastreadas
            hamburguesa.SetIngredientes(ingredientesExistentes);

            await context.Hamburguesas.AddAsync(hamburguesa);
            await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Hamburguesa hamburguesa)
        {
            var existingHamburguesa = await context.Hamburguesas
                .Include(h => h.Ingredientes)
                .Include(h => h.Precios)
                .FirstOrDefaultAsync(h => h.Id == hamburguesa.Id);

            if (existingHamburguesa == null)
                return false;
            if (!existingHamburguesa.Activo)
            {
                throw new InvalidOperationException("No se puede modificar una hamburguesa que se encuentra dada de baja.");
            }

            // 1. Actualizar datos simples
            existingHamburguesa.SetNombre(hamburguesa.Nombre);
            existingHamburguesa.SetDescripcion(hamburguesa.Descripcion);
            

            // 2. Actualizar ingredientes
            var idsIngredientes = hamburguesa.Ingredientes
                                        .Select(i => i.Id)
                                        .ToList();

            var ingredientesExistentes = await context.Ingredientes
                                                .Where(i => idsIngredientes.Contains(i.Id))
                                                .ToListAsync();

            existingHamburguesa.SetIngredientes(ingredientesExistentes);

            // 3. Verificar si llegó un precio nuevo
            var ultimoPrecioExistente = existingHamburguesa.Precios
                                            .OrderByDescending(p => p.FechaDesde)
                                            .FirstOrDefault();

            var ultimoPrecioRecibido = hamburguesa.Precios
                                            .OrderByDescending(p => p.FechaDesde)
                                            .FirstOrDefault();

            if (ultimoPrecioRecibido != null)
            {
                bool precioNuevo =
                    ultimoPrecioExistente == null ||
                    ultimoPrecioExistente.Monto != ultimoPrecioRecibido.Monto;

                if (precioNuevo)
                {
                    existingHamburguesa.AddPrecio(ultimoPrecioRecibido);
                }
            }

            // 4. Guardar todo
            await context.SaveChangesAsync();

            return true;
        }

        // Baja lógica. Reglas:
        //  - Si está en un pedido en curso (EnProceso, Listo, Asignado o EnCamino), no se puede dar de baja.
        //  - Los pedidos Pendientes que la incluyen se cancelan y quedan con un comentario final.
        //  - Los pedidos Entregados / Cancelados conservan la hamburguesa (es historial).
        public async Task<bool> DeactivateAsync(int id, string comentarioFinal)
        {
            var hamburguesa = await context.Hamburguesas.FirstOrDefaultAsync(h => h.Id == id);
            if (hamburguesa == null) return false;
            if (!hamburguesa.Activo)
            {
                throw new InvalidOperationException("La hamburguesa ya se encuentra dada de baja.");
            }

            var idsPedidos = await context.DetallesPedido
                .Where(d => d.HamburguesaId == id)
                .Select(d => d.PedidoId)
                .Distinct()
                .ToListAsync();

            var pedidos = await context.Pedidos
                .Where(p => idsPedidos.Contains(p.Id))
                .ToListAsync();

            var estadosEnCurso = new[] { EstadoPedido.EnProceso, EstadoPedido.Listo, EstadoPedido.Asignado, EstadoPedido.EnCamino };
            if (pedidos.Any(p => estadosEnCurso.Contains(p.Estado)))
            {
                throw new InvalidOperationException("No se puede eliminar la hamburguesa porque está en pedidos en curso.");
            }

            foreach (var pedido in pedidos.Where(p => p.Estado == EstadoPedido.Pendiente))
            {
                pedido.SetEstado(EstadoPedido.Cancelado);
                var texto = string.IsNullOrWhiteSpace(pedido.ComentarioFinal)
                    ? comentarioFinal
                    : pedido.ComentarioFinal + " | " + comentarioFinal;
                pedido.SetComentarioFinal(texto);
            }

            hamburguesa.SetActivo(false);

            await context.SaveChangesAsync();
            return true;
        }

        
    }
}