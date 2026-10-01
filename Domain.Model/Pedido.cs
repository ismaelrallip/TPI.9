using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Pedido
    {
        public int Id { get; private set; }
        public DateTime Fecha { get; private set; }
        public string? Comentario { get; private set; }
        public string Direccion { get; private set; }
        public ModalidadPedido Modalidad { get; private set; }
        public int CalificacionPedido { get; private set; }
        public int? CalificacionDelivery { get; private set; }
        public EstadoPedido Estado { get; private set; }
        public string? ComentarioFinal { get; private set; }
        public decimal PrecioTotal { get; private set; }

        private int _clienteId;
        private Cliente? _cliente;
        public int ClienteId
        {
            get => _cliente?.Id ?? _clienteId;
            private set => _clienteId = value;
        }

        public Cliente? Cliente
        {
            get => _cliente;
            private set
            {
                _cliente = value;
                if (value != null && _clienteId != value.Id)
                {
                    _clienteId = value.Id;
                }
            }
        }

        private int? _deliveryId;
        private Delivery? _delivery;
        public int? DeliveryId
        {
            get => _delivery?.IdDelivery ?? _deliveryId;
            private set => _deliveryId = value;
        }

        public Delivery? Delivery
        {
            get => _delivery;
            private set
            {
                _delivery = value;
                if (value != null && _deliveryId != value.IdDelivery)
                {
                    _deliveryId = value.IdDelivery;
                }
            }
        }

        private readonly List<DetallePedido> _detallePedido = new();
        public IReadOnlyList<DetallePedido> DetallePedido => _detallePedido.AsReadOnly();

        private Pedido() { } // Para EF Core
        // Constructor público para crear un pedido con los campos obligatorios
        public Pedido(int id, DateTime fecha, string direccion, ModalidadPedido modalidad, int clienteId)
        {
            SetId(id);
            SetFecha(fecha);
            SetDireccion(direccion);
            SetModalidad(modalidad);
            SetCliente(clienteId);
            Estado = EstadoPedido.Pendiente;
        }
        // Constructor público de pedido con todos los campos
        public Pedido(int id, DateTime fecha, string? comentario, string direccion, ModalidadPedido modalidad, EstadoPedido estado, string? comentarioFinal, decimal precioTotal, int clienteId, int deliveryId)
        {
            SetId(id);
            SetFecha(fecha);
            SetComentario(comentario);
            SetDireccion(direccion);
            SetModalidad(modalidad);
            SetEstado(estado);
            SetComentarioFinal(comentarioFinal);
            SetPrecioTotal(precioTotal);
            SetCliente(clienteId);
            SetDelivery(deliveryId);
        }

        public void SetCliente(int clienteId)
        {
            if (clienteId <= 0)
                throw new ArgumentException("El Id del cliente debe ser mayor que 0.", nameof(clienteId));
            ClienteId = clienteId;
        }

        public void SetDelivery(int? deliveryId)
        {
            if (deliveryId.HasValue && deliveryId <= 0)
                throw new ArgumentException("El Id del delivery debe ser mayor que 0.", nameof(deliveryId));
            DeliveryId = deliveryId;
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetFecha(DateTime fecha)
        {
            if (fecha == default)
                throw new ArgumentException("La fecha del pedido no puede ser nula.", nameof(fecha));
            Fecha = fecha;
        }

        public void SetComentario(string? comentario)
        {
            if (comentario != null && comentario.Length > 500)
                throw new ArgumentException("El comentario no puede exceder los 500 caracteres.", nameof(comentario));

            Comentario = comentario;
        }

        public void SetDireccion(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion) || direccion.Length < 1 || direccion.Length > 100)
                throw new ArgumentException("La dirección es obligatoria y debe tener entre 1 y 100 caracteres.", nameof(direccion));
            Direccion = direccion;
        }

        public void SetModalidad(ModalidadPedido modalidad)
        {
            Modalidad = modalidad;
        }

        public void SetEstado(EstadoPedido estado)
        {
            Estado = estado;
        }

        public void SetCalificacionPedido(int calificacionPedido)
        {
            if (calificacionPedido < 1 || calificacionPedido > 5)
                throw new ArgumentException("La calificación del pedido debe estar entre 1 y 5.", nameof(calificacionPedido));
            CalificacionPedido = calificacionPedido;
        }

        public void SetCalificacionDelivery(int? calificacionDelivery)
        {
            if (calificacionDelivery.HasValue && (calificacionDelivery < 1 || calificacionDelivery > 5))
                throw new ArgumentException("La calificación del delivery debe estar entre 1 y 5.", nameof(calificacionDelivery));
            CalificacionDelivery = calificacionDelivery;
        }

        public void SetComentarioFinal(string? comentarioFinal)
        {
            if (comentarioFinal != null && comentarioFinal.Length > 500)
                throw new ArgumentException("El comentario final no puede exceder los 500 caracteres.", nameof(comentarioFinal));
            
            ComentarioFinal = comentarioFinal;
        }

        public void SetPrecioTotal(decimal precioTotal)
        {
            if (precioTotal < 0)
                throw new ArgumentException("El precio total no puede ser negativo.", nameof(precioTotal));
            PrecioTotal = precioTotal;
        }

        public void AddItem(DetallePedido item)
        {
            if (Estado != EstadoPedido.Pendiente)
                throw new InvalidOperationException("Solo se pueden agregar items a pedidos pendientes.");
            ArgumentNullException.ThrowIfNull(item);
            _detallePedido.Add(item);
        }

        public void RemoveItem(DetallePedido item)
        {
            if (Estado != EstadoPedido.Pendiente)
                throw new InvalidOperationException("Solo se pueden eliminar items a pedidos pendientes.");
            ArgumentNullException.ThrowIfNull(item);
            _detallePedido.Remove(item);
        }

        public void ClearItems()
        {
            if (Estado != EstadoPedido.Pendiente)
                throw new InvalidOperationException("Solo se pueden eliminar todos los items a pedidos pendientes.");
            _detallePedido.Clear();
            PrecioTotal = 0;
        }

        public void RecalcularPrecioTotal(decimal costoDeliveryAplicado)
        {
            decimal subtotalItems = _detallePedido?.Sum(item => item.PrecioUnitario * item.Cantidad) ?? 0;

            decimal costoEnvio = (Modalidad == ModalidadPedido.Delivery) ? costoDeliveryAplicado : 0;

            PrecioTotal = subtotalItems + costoEnvio;
        }

        public void Calificar(int calificacionPedido, int calificacionDelivery, string comentarioFinal)
        {
            // Validar que el pedido esté en un estado válido para ser calificado (ej. Entregado)
            if (Estado != EstadoPedido.Entregado)
                throw new InvalidOperationException("Solo se pueden calificar pedidos entregados.");

            SetCalificacionPedido(calificacionPedido);
            SetCalificacionDelivery(calificacionDelivery);
            SetComentarioFinal(comentarioFinal);
        }
    }
}
