using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private static readonly List<Delivery> deliveries = new List<Delivery>();
        private static int nextId = 1;

        public Task AddAsync(Delivery delivery)
        {
            // Simular auto-increment de ID
            delivery.SetIdDelivery(nextId);
            nextId++;

            deliveries.Add(delivery);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var delivery = deliveries.FirstOrDefault(c => c.IdDelivery == id);
            if (delivery != null)
            {
                deliveries.Remove(delivery);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<Delivery?> GetAsync(int id)
        {
            return Task.FromResult(deliveries.FirstOrDefault(c => c.IdDelivery == id));
        }

        public Task<IEnumerable<Delivery>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Delivery>>(deliveries.ToList());
        }

        public Task<bool> UpdateAsync(Delivery delivery)
        {
            var existing = deliveries.FirstOrDefault(c => c.IdDelivery == delivery.IdDelivery);
            if (existing != null)
            {
                existing.SetNombre(delivery.Nombre);
                existing.SetApellido(delivery.Apellido);
                existing.SetTelefono(delivery.Telefono);
                existing.SetDni(delivery.Dni);

                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> DniExistsAsync(int dni, int? excludeId = null)
        {
            var query = deliveries.Where(c => c.Dni == dni);
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.IdDelivery != excludeId.Value);
            }
            return Task.FromResult(query.Any());
        }
    }
}
