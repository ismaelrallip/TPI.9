using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DetallePedidoRepository : IDetallePedidoRepository
    {
        private readonly TPIContext context;
        public DetallePedidoRepository(TPIContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(DetallePedido detallePedido)
        {
            context.DetallesPedido.Add(detallePedido);
            await context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var detallePedido = await context.DetallesPedido.FindAsync(id);
            if (detallePedido == null)
                return false;
            context.DetallesPedido.Remove(detallePedido);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<DetallePedido?> GetAsync(int id)
        {
            return await context.DetallesPedido.FindAsync(id);
        }
        public async Task<IEnumerable<DetallePedido>> GetAllAsync()
        {
            return await context.DetallesPedido.ToListAsync();
        }
        public async Task<bool> UpdateAsync(DetallePedido detallePedido)
        {
            var existingDetallePedido = await context.DetallesPedido.FindAsync(detallePedido.Id);
            if (existingDetallePedido == null)
                return false;
            context.DetallesPedido.Update(detallePedido);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<DetallePedido>> GetByPedidoIdAsync(int pedidoId)
        {
            return await context.DetallesPedido
                .Where(dp => dp.PedidoId == pedidoId)
                .ToListAsync();
        }
        public async Task<IEnumerable<DetallePedido>> GetByHamburguesaIdAsync(int hamburguesaId)
        {
            return await context.DetallesPedido
                .Where(dp => dp.HamburguesaId == hamburguesaId)
                .ToListAsync();
        }
        public async Task<IEnumerable<DetallePedido>> GetByPedidoIdWithHamburguesaAsync(int pedidoId)
        {
            return await context.DetallesPedido
                .Where(dp => dp.PedidoId == pedidoId)
                .Include(dp => dp.Hamburguesa)
                .ToListAsync();
        }
    }
}
