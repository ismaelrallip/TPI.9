using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IPedidoRepository
    {
        Task AddAsync(Pedido pedido);
        Task<bool> DeleteAsync(int id);
        Task<Pedido?> GetAsync(int id);
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task<bool> UpdateAsync(Pedido pedido);
        Task<Pedido?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<Pedido>> GetByClienteIdAsync(int clienteId);
        Task<IEnumerable<Pedido>> GetByDeliveryIdAsync(int deliveryId);
        Task<IEnumerable<Pedido>> GetByEstadoAsync(EstadoPedido estado);
    }
}
