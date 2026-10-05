using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly TPIContext context;

        public PedidoRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Pedido pedido)
        {
            context.Pedidos.Add(pedido);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pedido = await context.Pedidos.FindAsync(id);
            if (pedido == null)
                return false;
            context.Pedidos.Remove(pedido);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Pedido?> GetAsync(int id)
        {
            return await context.Pedidos.FindAsync(id);
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Delivery)
                .Include(p => p.DetallePedido)
                    .ThenInclude(d => d.Hamburguesa)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Pedido pedido)
        {
            var existingPedido = await context.Pedidos
                .Include(p => p.DetallePedido)
                .FirstOrDefaultAsync(p => p.Id == pedido.Id);

            
            if (existingPedido != null)
            {
                existingPedido.SetCliente(pedido.ClienteId);

               
                existingPedido.SetDelivery(pedido.DeliveryId);

                existingPedido.SetComentario(pedido.Comentario);
                existingPedido.SetDireccion(pedido.Direccion);
                existingPedido.SetModalidad(pedido.Modalidad);
                existingPedido.SetFecha(pedido.Fecha);

                
                if (existingPedido.Estado == EstadoPedido.Pendiente)
                {
                    var itemsToDelete = existingPedido.DetallePedido
                        .Where(existing => !pedido.DetallePedido.Any(nuevo => nuevo.HamburguesaId == existing.HamburguesaId))
                        .ToList();

                    foreach (var itemToDelete in itemsToDelete)
                    {
                        existingPedido.RemoveItem(itemToDelete);
                    }

                    foreach (var nuevoItem in pedido.DetallePedido)
                    {
                        var existingItem = existingPedido.DetallePedido
                            .FirstOrDefault(e => e.HamburguesaId == nuevoItem.HamburguesaId);

                        if (existingItem != null)
                        {
                            existingItem.SetCantidad(nuevoItem.Cantidad);
                            existingItem.SetPrecioUnitario(nuevoItem.PrecioUnitario);
                        }
                        else
                        {
                           
                            existingPedido.AddItem(new DetallePedido(0, nuevoItem.Cantidad, nuevoItem.PrecioUnitario, nuevoItem.HamburguesaId, existingPedido.Id));
                        }
                    }
                }

                
                existingPedido.SetEstado(pedido.Estado);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Pedido?> GetByIdWithDetailsAsync(int id)
        {
            return await context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Delivery)
                .Include(p => p.DetallePedido)
                    .ThenInclude(d => d.Hamburguesa)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pedido>> GetByClienteIdAsync(int clienteId)
        {
            return await context.Pedidos
                .Where(p => p.ClienteId == clienteId)
                .Include(p => p.Cliente)
                .Include(p => p.Delivery)
                .Include(p => p.DetallePedido)
                    .ThenInclude(dp => dp.Hamburguesa)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> GetByDeliveryIdAsync(int deliveryId)
        {
            return await context.Pedidos
                .Where(p => p.DeliveryId == deliveryId)
                .Include(p => p.Cliente)
                .Include(p => p.Delivery)
                .Include(p => p.DetallePedido)
                    .ThenInclude(dp => dp.Hamburguesa)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> GetByEstadoAsync(EstadoPedido estado)
        {
            return await context.Pedidos
                .Where(p => p.Estado == estado)
                .Include(p => p.Cliente)
                .Include(p => p.Delivery)
                .Include(p => p.DetallePedido)
                    .ThenInclude(dp => dp.Hamburguesa)
                .ToListAsync();
        }
    }
}