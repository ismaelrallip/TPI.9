using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDetallePedidoRepository
    {
        Task AddAsync(DetallePedido detallePedido);
        Task<bool> DeleteAsync(int id);
        Task<DetallePedido?> GetAsync(int id);
        Task<IEnumerable<DetallePedido>> GetAllAsync();
        Task<bool> UpdateAsync(DetallePedido detallePedido);
        Task<IEnumerable<DetallePedido>> GetByPedidoIdAsync(int pedidoId);
        Task<IEnumerable<DetallePedido>> GetByHamburguesaIdAsync(int hamburguesaId);
        Task<IEnumerable<DetallePedido>> GetByPedidoIdWithHamburguesaAsync(int pedidoId);
    }
}
