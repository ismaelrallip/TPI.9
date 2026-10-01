using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class DetallePedido
    {
        public int Id { get; private set; }
        public int Cantidad { get; private set; }

        public decimal PrecioUnitario { get; private set; }

        private int _hamburguesaId;
        private Hamburguesa? _hamburguesa;
        public int HamburguesaId
        {
            get => _hamburguesa?.Id ?? _hamburguesaId;
            private set => _hamburguesaId = value;
        }
        public Hamburguesa? Hamburguesa
        {
            get => _hamburguesa;
            private set
            {
                _hamburguesa = value;
                if (value != null && _hamburguesaId != value.Id)
                {
                    _hamburguesaId = value.Id;
                }
            }
        }
        private int _pedidoId;
        private Pedido? _pedido;
        public int PedidoId
        {
            get => _pedido?.Id ?? _pedidoId;
            private set => _pedidoId = value;
        }
        public Pedido? Pedido
        {
            get => _pedido;
            private set
            {
                _pedido = value;
                if (value != null && _pedidoId != value.Id)
                {
                    _pedidoId = value.Id;
                }
            }
        }

        public DetallePedido(int id, int cantidad, decimal precioUnitario, int hamburguesaId, int pedidoId)
        {
            SetId(id);
            SetCantidad(cantidad);
            SetHamburguesa(hamburguesaId);
            SetPedido(pedidoId);
            SetPrecioUnitario(precioUnitario);
        }

        public void SetId(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El Id debe ser mayor o igual a cero.");
            }
            Id = id;
        }

        public void SetCantidad(int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            }
            Cantidad = cantidad;
        }

        public void SetHamburguesa(Hamburguesa hamburguesa)
        {
            if (hamburguesa == null)
            {
                throw new ArgumentNullException(nameof(hamburguesa), "La hamburguesa no puede ser nula.");
            }
            Hamburguesa = hamburguesa;
        }

        public void SetPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo.");
            }
            Pedido = pedido;
        }

        public void SetPrecioUnitario(decimal precioUnitario)
        {
            if (precioUnitario < 0)
            {
                throw new ArgumentException("El precio unitario debe ser mayor o igual a cero.");
            }
            PrecioUnitario = precioUnitario;
        }

        public void SetHamburguesa(int hamburguesaId)
        {
            if (hamburguesaId <= 0)
            {
                throw new ArgumentException("El Id de la hamburguesa debe ser mayor que cero.");
            }
            HamburguesaId = hamburguesaId;
        }

        public void SetPedido(int pedidoId)
        {
            if (pedidoId <= 0)
            {
                throw new ArgumentException("El Id del pedido debe ser mayor que cero.");
            }
            PedidoId = pedidoId;
        }
    }
}