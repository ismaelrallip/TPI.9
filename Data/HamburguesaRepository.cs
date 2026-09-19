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
            return await context.Hamburguesas.FindAsync(id);
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

        public async Task<bool> DeleteAsync(int id)
        {
            var hamburguesa = await context.Hamburguesas.FindAsync(id);
            if (hamburguesa == null)
                return false;

            context.Hamburguesas.Remove(hamburguesa);
            await context.SaveChangesAsync();
            return true;
        }
    }
}