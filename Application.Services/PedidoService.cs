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
        private readonly IClienteRepository _clienteRepository;
        private readonly IDeliveryRepository _deliveryRepository;

        public PedidoService(IPedidoRepository pedidoRepository,
                             IHamburguesaRepository hamburguesaRepository,
                             IPrecioDeliveryRepository precioDeliveryRepository,
                             IClienteRepository clienteRepository,
                             IDeliveryRepository deliveryRepository)
        {
            _pedidoRepository = pedidoRepository;
            _hamburguesaRepository = hamburguesaRepository;
            _precioDeliveryRepository = precioDeliveryRepository;
            _clienteRepository = clienteRepository;
            _deliveryRepository = deliveryRepository;
        }

        public async Task<PedidoDTO> AddAsync(PedidoDTO dto)
        {
            var clienteExistente = await _clienteRepository.GetAsync(dto.ClienteId);
            if (clienteExistente == null)
                throw new ArgumentException($"El cliente con ID {dto.ClienteId} no existe.");
           
            if (!clienteExistente.Activo)
                throw new ArgumentException("El cliente seleccionado está dado de baja y no puede realizar pedidos.");

            if (dto.DetallesPedido == null || dto.DetallesPedido.Count == 0)
                throw new ArgumentException("El pedido debe tener al menos una hamburguesa.");



            var fechaPedido = DateTime.Now;

            // Validamos y determinamos la dirección según la modalidad
            string direccionFinal = null;
            if (dto.Modalidad == ModalidadPedido.Delivery)
            {
                if (string.IsNullOrWhiteSpace(dto.Direccion))
                    throw new ArgumentException("La dirección es obligatoria para pedidos con delivery.");

                direccionFinal = dto.Direccion.Trim();
            }

            var pedido = new Pedido(0, fechaPedido, dto.Comentario, direccionFinal, dto.Modalidad, dto.ClienteId);

            // Asignar comentario si viene desde DTO
            if (!string.IsNullOrWhiteSpace(dto.Comentario))
            {
                pedido.SetComentario(dto.Comentario);
            }

            if (dto.Modalidad == ModalidadPedido.Delivery && dto.DeliveryId.HasValue)
            {
                await ValidarDeliveryActivoAsync(dto.DeliveryId);
                pedido.SetDelivery(dto.DeliveryId.Value);
            }

            // El envío se cobra a todo pedido Delivery, tenga o no repartidor asignado todavía
            decimal costoDelivery = await ObtenerCostoDeliveryAsync(dto.Modalidad, fechaPedido);

            foreach (var detalleDto in dto.DetallesPedido)
            {
                var hamburguesa = await _hamburguesaRepository.GetByIdAsync(detalleDto.HamburguesaId);
                if (hamburguesa == null)
                    throw new ArgumentException($"La hamburguesa con ID {detalleDto.HamburguesaId} no existe.");
                if (!hamburguesa.Activo)
                    throw new ArgumentException($"La hamburguesa '{hamburguesa.Nombre}' ya no está disponible.");

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

        public async Task<bool> UpdateAsync(PedidoDTO dto, bool esAdmin)
        {
            var pedidoExistente = await _pedidoRepository.GetByIdWithDetailsAsync(dto.Id);
            if (pedidoExistente == null) return false;

            // Mientras está Pendiente se pueden editar las líneas, pero no puede quedar sin ninguna
            if (pedidoExistente.Estado == EstadoPedido.Pendiente &&
                (dto.DetallesPedido == null || dto.DetallesPedido.Count == 0))
                throw new ArgumentException("El pedido debe tener al menos una hamburguesa.");

            var fechaPedido = pedidoExistente.Fecha;

            // Control Estricto de Estado: El cliente solo puede pasar de Pendiente a Cancelado
            if (dto.Estado != pedidoExistente.Estado)
            {
                if (!esAdmin)
                {
                    // Reglas estrictas para el Cliente
                    if (pedidoExistente.Estado == EstadoPedido.Pendiente && dto.Estado == EstadoPedido.Cancelado)
                    {
                        pedidoExistente.SetEstado(EstadoPedido.Cancelado);
                    }
                    else
                    {
                        throw new InvalidOperationException("Operación no autorizada. El cliente solo puede cancelar un pedido pendiente.");
                    }
                }
                else
                {
                    // El administrador puede cambiar los estados normalmente
                    pedidoExistente.SetEstado(dto.Estado);
                }
            }

            // Regla: Calificaciones y comentarios finales SOLO aplican si el pedido ya fue entregado
            if (pedidoExistente.Estado == EstadoPedido.Entregado)
            {
                pedidoExistente.SetComentarioFinal(dto.ComentarioFinal);
                pedidoExistente.SetCalificacionPedido(dto.CalificacionPedido);
                pedidoExistente.SetCalificacionDelivery(dto.CalificacionDelivery);
            }

            // Asignación / reasignación de delivery (solo el administrador, en pedidos Delivery Pendientes o Asignados).
            // Va ANTES del bloque "Pendiente": al pasar de Pendiente a Asignado ese bloque ya no se ejecuta.
            if (esAdmin
                && pedidoExistente.Modalidad == ModalidadPedido.Delivery
                && (pedidoExistente.Estado == EstadoPedido.Pendiente || pedidoExistente.Estado == EstadoPedido.Asignado)
                && dto.DeliveryId != pedidoExistente.DeliveryId)
            {
                await ValidarDeliveryActivoAsync(dto.DeliveryId);
                pedidoExistente.SetDelivery(dto.DeliveryId);
            }

            // Los items, comentarios y la dirección solo se pueden modificar mientras el pedido está Pendiente.
            if (pedidoExistente.Estado == EstadoPedido.Pendiente)
            {
                pedidoExistente.SetComentario(dto.Comentario);

                // Primero se aplican cliente y modalidad: SetDireccion valida según la modalidad que tiene el propio pedido
                pedidoExistente.SetCliente(dto.ClienteId);
                pedidoExistente.SetModalidad(dto.Modalidad);

                // Validamos la dirección según la modalidad elegida
                if (dto.Modalidad == ModalidadPedido.Delivery)
                {
                    if (string.IsNullOrWhiteSpace(dto.Direccion))
                        throw new ArgumentException("La dirección es obligatoria para pedidos con delivery.");

                    pedidoExistente.SetDireccion(dto.Direccion.Trim());
                    pedidoExistente.SetDelivery(dto.DeliveryId);
                }
                else
                {
                    // Si es Take Away, no lleva dirección ni delivery
                    pedidoExistente.SetDireccion(null);
                    pedidoExistente.SetDelivery(null);
                }

                var itemsToDelete = pedidoExistente.DetallePedido
                    .Where(e => !dto.DetallesPedido.Any(n => n.HamburguesaId == e.HamburguesaId)).ToList();

                foreach (var item in itemsToDelete)
                {
                    pedidoExistente.RemoveItem(item);
                }

                foreach (var nuevoItem in dto.DetallesPedido)
                {
                    var hamburguesa = await _hamburguesaRepository.GetByIdAsync(nuevoItem.HamburguesaId);
                    if (hamburguesa == null)
                        throw new InvalidOperationException($"La hamburguesa con ID {nuevoItem.HamburguesaId} no existe.");
                    if (!hamburguesa.Activo)
                        throw new ArgumentException($"La hamburguesa '{hamburguesa.Nombre}' ya no está disponible.");

                    // Precio vigente a la fecha del pedido
                    var precioVigente = hamburguesa.ObtenerPrecioVigente(fechaPedido);

                    var existingItem = pedidoExistente.DetallePedido.FirstOrDefault(e => e.HamburguesaId == nuevoItem.HamburguesaId);
                    if (existingItem != null)
                    {
                        existingItem.SetCantidad(nuevoItem.Cantidad);
                        existingItem.SetPrecioUnitario(precioVigente);
                    }
                    else
                    {
                        pedidoExistente.AddItem(new DetallePedido(0, nuevoItem.Cantidad, precioVigente, hamburguesa.Id, pedidoExistente.Id));
                    }
                }
            }

            // Total: misma lógica que el alta 
            var costoDelivery = await ObtenerCostoDeliveryAsync(pedidoExistente.Modalidad, fechaPedido);
            pedidoExistente.RecalcularPrecioTotal(costoDelivery);

            return await _pedidoRepository.UpdateAsync(pedidoExistente);
        }
        // El delivery elegido tiene que existir y no estar dado de baja
        private async Task ValidarDeliveryActivoAsync(int? deliveryId)
        {
            if (!deliveryId.HasValue) return;

            var delivery = await _deliveryRepository.GetAsync(deliveryId.Value);
            if (delivery == null || !delivery.Activo)
                throw new ArgumentException("El delivery seleccionado no existe o fue dado de baja.");
        }

        private async Task<decimal> ObtenerCostoDeliveryAsync(ModalidadPedido modalidad, DateTime fecha)
        {
            if (modalidad != ModalidadPedido.Delivery) return 0;

            var precioDelivery = await _precioDeliveryRepository.GetByFechaAsync(fecha);
            return precioDelivery?.ObtenerPrecioVigente(fecha) ?? 0;
        }

        public async Task<IEnumerable<PedidoDTO>> GetByClienteIdAsync(int clienteId)
        {
            var pedidos = await _pedidoRepository.GetByClienteIdAsync(clienteId);
            return pedidos.Select(p => MapToDTO(p)).ToList();
        }

        public async Task<IEnumerable<PedidoDTO>> GetByClienteIdAsync(int clienteId, DateTime? fecha, ModalidadPedido? modalidad)
        {
            var pedidos = await _pedidoRepository.GetByClienteIdAsync(clienteId, fecha, modalidad);
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
                ClienteActivo = pedido.Cliente != null ? pedido.Cliente.Activo : false,
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
        public async Task<IEnumerable<PedidoDTO>> GetByFiltroAsync(DateTime? fecha, ModalidadPedido? modalidad)
        {
            var pedidos = await _pedidoRepository.GetByFiltroAsync(fecha, modalidad);
            return pedidos.Select(pedido => MapToDTO(pedido)).ToList();
        }

        public async Task<IEnumerable<PedidoDTO>> GetByFiltroAsync(DateTime? desde,DateTime? hasta,ModalidadPedido? modalidad,EstadoPedido? estado)
        {
            var pedidos = await _pedidoRepository.GetByFiltroAsync(desde, hasta, modalidad, estado);
            return pedidos.Select(pedido => MapToDTO(pedido)).ToList();
        }
    }
}