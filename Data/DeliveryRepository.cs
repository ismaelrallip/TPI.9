using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly TPIContext context;

        public DeliveryRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Delivery delivery)
        {
            context.Deliveries.Add(delivery);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var delivery = await context.Deliveries.FindAsync(id);
            if (delivery != null)
            {
                context.Deliveries.Remove(delivery);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Delivery?> GetAsync(int id)
        {
            return await context.Deliveries.FindAsync(id);
        }

        public async Task<IEnumerable<Delivery>> GetAllAsync()
        {
            return await context.Deliveries.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Delivery delivery)
        {
            var existing = await context.Deliveries.FindAsync(delivery.IdDelivery);
            if (existing != null)
            {
                existing.SetNombre(delivery.Nombre);
                existing.SetApellido(delivery.Apellido);
                existing.SetTelefono(delivery.Telefono);
                existing.SetDni(delivery.Dni);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DniExistsAsync(int dni, int? excludeId = null)
        {
            var query = context.Deliveries.Where(c => c.Dni == dni);
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.IdDelivery != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<bool> TelefonoExistsAsync(string telefono, int? excludeId = null)
        {
            var query = context.Deliveries.Where(c => c.Telefono == telefono);
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.IdDelivery != excludeId.Value);
            }
            return await query.AnyAsync();
        }
    }
}
