using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPedidoService
    {
        Task<PedidoDTO> AddAsync(PedidoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<PedidoDTO?> GetAsync(int id);
        Task<IEnumerable<PedidoDTO>> GetAllAsync();
        public Task<bool> UpdateAsync(PedidoDTO dto, bool esAdmin);
        Task<IEnumerable<PedidoDTO>> GetByClienteIdAsync(int clienteId);
        Task<IEnumerable<PedidoDTO>> GetByClienteIdAsync(int clienteId, DateTime? fecha, ModalidadPedido? modalidad);
        Task<IEnumerable<PedidoDTO>> GetByDeliveryIdAsync(int deliveryId);
        Task<IEnumerable<PedidoDTO>> GetByEstadoAsync(EstadoPedido estado);
        Task<IEnumerable<PedidoDTO>> GetByFiltroAsync(DateTime? fecha, ModalidadPedido? modalidad);
    }
}
