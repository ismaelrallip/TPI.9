using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PrecioDeliveryRepository : IPrecioDeliveryRepository
    {
        private readonly TPIContext context;

        public PrecioDeliveryRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(PrecioDelivery precioDelivery)
        {
            await context.PreciosDelivery.AddAsync(precioDelivery);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var precioDelivery = await context.PreciosDelivery.FindAsync(id);
            if (precioDelivery == null)
                return false;

            context.PreciosDelivery.Remove(precioDelivery);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<PrecioDelivery?> GetAsync(int id)
        {
            return await context.PreciosDelivery.FindAsync(id);
        }

        public async Task<IEnumerable<PrecioDelivery>> GetAllAsync()
        {
            return await context.PreciosDelivery.ToListAsync();
        }

        public async Task<bool> UpdateAsync(PrecioDelivery precioDelivery)
        {
            var existingPrecioDelivery = await context.PreciosDelivery.FindAsync(precioDelivery.Id);
            if (existingPrecioDelivery == null)
                return false;
            existingPrecioDelivery.SetValor(precioDelivery.Monto);
            existingPrecioDelivery.SetFecha(precioDelivery.FechaDesde);
            context.PreciosDelivery.Update(existingPrecioDelivery);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
