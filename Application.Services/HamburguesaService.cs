using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public class HamburguesaService : IHamburguesaService
    {
        private readonly IHamburguesaRepository hamburguesaRepository;
        private readonly IIngredienteRepository ingredienteRepository;

        public HamburguesaService(IHamburguesaRepository hamburguesaRepository, IIngredienteRepository ingredienteRepository)
        {
            this.hamburguesaRepository = hamburguesaRepository;
            this.ingredienteRepository = ingredienteRepository;
        }

        public async Task<HamburguesaDTO> AddAsync(HamburguesaDTO dto)
        {
            // El servicio arma las entidades: el precio (con la fecha de hoy) y los ingredientes existentes
            var precios = new List<Precio>();
            var montoRecibido = ObtenerMontoRecibido(dto);
            if (montoRecibido.HasValue)
            {
                precios.Add(new Precio(DateTime.Now, montoRecibido.Value));
            }

            var ingredientes = await ObtenerIngredientesAsync(dto);

            Hamburguesa hamburguesa = new Hamburguesa(0, dto.Nombre, dto.Descripcion, precios, ingredientes);
            await hamburguesaRepository.AddAsync(hamburguesa);

            return ToDto(hamburguesa);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hamburguesa = await hamburguesaRepository.GetByIdAsync(id);
            if (hamburguesa == null) return false;

            // Baja lógica: los pedidos Pendientes que la incluyen se cancelan con este comentario final
            string comentarioFinal = $"Hamburguesa '{hamburguesa.Nombre}' dada de baja por el administrador.";
            return await hamburguesaRepository.DeactivateAsync(id, comentarioFinal);
        }

        public async Task<HamburguesaDTO?> GetAsync(int id)
        {
            Hamburguesa? hamburguesa = await hamburguesaRepository.GetByIdAsync(id);
            return hamburguesa == null ? null : ToDto(hamburguesa);
        }

        public async Task<IEnumerable<HamburguesaDTO>> GetAllAsync()
        {
            var hamburguesas = await hamburguesaRepository.GetAllAsync();
            return hamburguesas.Select(ToDto).ToList();
        }

        public async Task<IEnumerable<HamburguesaDTO>> GetByCriteriaAsync(string texto)
        {
            var hamburguesas = await hamburguesaRepository.GetByCriteriaAsync(texto ?? string.Empty);
            return hamburguesas.Select(ToDto).ToList();
        }

        public async Task<bool> UpdateAsync(HamburguesaDTO dto)
        {
            var existing = await hamburguesaRepository.GetByIdAsync(dto.Id);
            if (existing == null) return false;
            
            if (!existing.Activo)
            {
                throw new InvalidOperationException("No se puede modificar una hamburguesa que se encuentra dada de baja.");
            }

            var ingredientes = await ObtenerIngredientesAsync(dto);

            // Solo se crea un precio nuevo (con la fecha de hoy) si el monto recibido es distinto del vigente.
            // Si no llega ningun precio o es el mismo, se conservan los precios existentes.
            var montoRecibido = ObtenerMontoRecibido(dto);
            var ultimoExistente = existing.Precios.OrderByDescending(p => p.FechaDesde).FirstOrDefault();

            List<Precio> precios = (montoRecibido.HasValue && montoRecibido != ultimoExistente?.Monto)
                ? new List<Precio> { new Precio(DateTime.Now, montoRecibido.Value) }
                : existing.Precios.ToList();

            Hamburguesa hamburguesa = new Hamburguesa(dto.Id, dto.Nombre, dto.Descripcion, precios, ingredientes);
            return await hamburguesaRepository.UpdateAsync(hamburguesa);
        }

        // Monto del precio mas reciente que mando el cliente (null si no mando ninguno)
        private static decimal? ObtenerMontoRecibido(HamburguesaDTO dto)
        {
            var ultimo = dto.Precios?.OrderByDescending(p => p.FechaDesde).FirstOrDefault();
            if (ultimo == null) return null;

            if (ultimo.Monto < 0)
                throw new ArgumentException("El precio debe ser mayor o igual a 0.");

            return ultimo.Monto;
        }

        // Busca las entidades de los ingredientes a partir de los Id que mando el cliente
        private async Task<List<Ingrediente>> ObtenerIngredientesAsync(HamburguesaDTO dto)
        {
            var ids = (dto.Ingredientes ?? new List<IngredienteDTO>()).Select(i => i.Id).Distinct().ToList();

            var ingredientes = new List<Ingrediente>();
            foreach (var id in ids)
            {
                var ingrediente = await ingredienteRepository.GetAsync(id);
                if (ingrediente == null)
                    throw new ArgumentException($"El ingrediente con ID {id} no existe.");

                ingredientes.Add(ingrediente);
            }

            // Hamburguesa.SetIngredientes exige al menos uno
            return ingredientes;
        }

        private static HamburguesaDTO ToDto(Hamburguesa hamburguesa)
        {
            return new HamburguesaDTO
            {
                Id = hamburguesa.Id,
                Nombre = hamburguesa.Nombre,
                Descripcion = hamburguesa.Descripcion,
                Activo = hamburguesa.Activo,
                Precios = hamburguesa.Precios
                    .OrderBy(p => p.FechaDesde)
                    .Select(p => new PrecioDTO { FechaDesde = p.FechaDesde, Monto = p.Monto })
                    .ToList(),
                Ingredientes = hamburguesa.Ingredientes
                    .Select(i => new IngredienteDTO { Id = i.Id, Nombre = i.Nombre, Descripcion = i.Descripcion, Stock = i.Stock })
                    .ToList()
            };
        }
    }
}