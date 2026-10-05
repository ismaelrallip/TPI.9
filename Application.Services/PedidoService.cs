using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IHamburguesaRepository _hamburguesaRepository;
        private readonly IPrecioDeliveryRepository _precioDeliveryRepository;

        public PedidoService(IPedidoRepository pedidoRepository,
                             IHamburguesaRepository hamburguesaRepository,
                             IPrecioDeliveryRepository precioDeliveryRepository)
        {
            _pedidoRepository = pedidoRepository;
            _hamburguesaRepository = hamburguesaRepository;
            _precioDeliveryRepository = precioDeliveryRepository;
        }

        public async Task<PedidoDTO> AddAsync(PedidoDTO dto)
        {
            var fechaPedido = DateTime.Now;
            var pedido = new Pedido(0, fechaPedido, dto.Direccion, dto.Modalidad, dto.ClienteId);

            decimal costoDelivery = 0;

            if (dto.Modalidad == ModalidadPedido.Delivery && dto.DeliveryId.HasValue)
            {
                pedido.SetDelivery(dto.DeliveryId.Value);
                var precioDeliveryEntity = await _precioDeliveryRepository.GetByFechaAsync(fechaPedido);

                if (precioDeliveryEntity != null)
                {
                    
                    costoDelivery = precioDeliveryEntity.ObtenerPrecioVigente(fechaPedido);
                }
            }

            foreach (var detalleDto in dto.DetallesPedido)
            {
                var hamburguesa = await _hamburguesaRepository.GetByIdAsync(detalleDto.HamburguesaId);
                if (hamburguesa == null)
                    throw new Exception($"La hamburguesa con ID {detalleDto.HamburguesaId} no existe.");

                var precioVigente = hamburguesa.ObtenerPrecioVigente(fechaPedido);
                var item = new DetallePedido(detalleDto.Id, detalleDto.Cantidad, precioVigente, hamburguesa.Id, pedido.Id);

                pedido.AddItem(item);
            }

            pedido.RecalcularPrecioTotal(costoDelivery);

            await _pedidoRepository.AddAsync(pedido);

            dto.Id = pedido.Id;
            dto.Fecha = pedido.Fecha;
            dto.PrecioTotal = pedido.PrecioTotal;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _pedidoRepository.DeleteAsync(id);
        }

        public async Task<PedidoDTO?> GetAsync(int id)
        {
            Pedido? pedido = await _pedidoRepository.GetByIdWithDetailsAsync(id);
            return pedido == null ? null : MapToDTO(pedido);
        }

        public async Task<IEnumerable<PedidoDTO>> GetAllAsync()
        {
            var pedidos = await _pedidoRepository.GetAllAsync();
            return pedidos.Select(pedido => MapToDTO(pedido)).ToList();
        }

        public async Task<bool> UpdateAsync(PedidoDTO dto)
        {
            
            var pedidoExistente = await _pedidoRepository.GetByIdWithDetailsAsync(dto.Id);
            if (pedidoExistente == null) return false;

            
            pedidoExistente.SetEstado(dto.Estado);
            pedidoExistente.SetComentario(dto.Comentario);
            pedidoExistente.SetComentarioFinal(dto.ComentarioFinal);
            pedidoExistente.SetDelivery(dto.DeliveryId); 

            
            if (pedidoExistente.Estado == EstadoPedido.Pendiente)
            {
                pedidoExistente.SetDireccion(dto.Direccion);

                var itemsToDelete = pedidoExistente.DetallePedido
                    .Where(e => !dto.DetallesPedido.Any(n => n.HamburguesaId == e.HamburguesaId)).ToList();

                foreach (var item in itemsToDelete)
                {
                    pedidoExistente.RemoveItem(item);
                }

                foreach (var nuevoItem in dto.DetallesPedido)
                {
                    var existingItem = pedidoExistente.DetallePedido.FirstOrDefault(e => e.HamburguesaId == nuevoItem.HamburguesaId);
                    if (existingItem != null)
                    {
                        existingItem.SetCantidad(nuevoItem.Cantidad);
                        existingItem.SetPrecioUnitario(nuevoItem.PrecioUnitario);
                    }
                    else
                    {
                        pedidoExistente.AddItem(new DetallePedido(0, nuevoItem.Cantidad, nuevoItem.PrecioUnitario, nuevoItem.HamburguesaId, pedidoExistente.Id));
                    }
                }
            }

            
            return await _pedidoRepository.UpdateAsync(pedidoExistente);
        }

        public async Task<IEnumerable<PedidoDTO>> GetByClienteIdAsync(int clienteId)
        {
            var pedidos = await _pedidoRepository.GetByClienteIdAsync(clienteId);
            return pedidos.Select(p => MapToDTO(p)).ToList();
        }

        public async Task<IEnumerable<PedidoDTO>> GetByDeliveryIdAsync(int deliveryId)
        {
            var pedidos = await _pedidoRepository.GetByDeliveryIdAsync(deliveryId);
            return pedidos.Select(p => MapToDTO(p)).ToList();
        }

        public async Task<IEnumerable<PedidoDTO>> GetByEstadoAsync(EstadoPedido estado)
        {
            var pedidos = await _pedidoRepository.GetByEstadoAsync(estado);
            return pedidos.Select(p => MapToDTO(p)).ToList();
        }

        private PedidoDTO MapToDTO(Pedido pedido)
        {
            return new PedidoDTO
            {
                Id = pedido.Id,
                ClienteId = pedido.ClienteId,
                ClienteNombre = pedido.Cliente != null ? $"{pedido.Cliente.Nombre} {pedido.Cliente.Apellido}" : null,
                DeliveryId = pedido.DeliveryId,
                DeliveryNombre = pedido.Delivery != null ? $"{pedido.Delivery.Nombre} {pedido.Delivery.Apellido}" : null,
                Fecha = pedido.Fecha,
                PrecioTotal = pedido.PrecioTotal,
                CalificacionDelivery = pedido.CalificacionDelivery,
                CalificacionPedido = pedido.CalificacionPedido,
                Estado = pedido.Estado,
                Modalidad = pedido.Modalidad,
                Direccion = pedido.Direccion,
                Comentario = pedido.Comentario,
                ComentarioFinal = pedido.ComentarioFinal,
                DetallesPedido = pedido.DetallePedido?.Select(item => new DetallePedidoDTO
                {
                    Id = item.Id,
                    PedidoId = item.PedidoId,
                    HamburguesaId = item.HamburguesaId,
                    HamburguesaNombre = item.Hamburguesa?.Nombre,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario
                }).ToList() ?? new List<DetallePedidoDTO>()
            };
        }
    }
}