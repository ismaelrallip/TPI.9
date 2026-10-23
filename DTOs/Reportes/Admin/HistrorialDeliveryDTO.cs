using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTOs.Reportes.Admin
{
    public class HistorialDeliveryItemDTO
    {
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public EstadoPedido Estado { get; set; }
        public int? CalificacionDelivery { get; set; }
        public decimal PrecioTotal { get; set; }
    }

    public class HistrorialDeliveryDTO
    {
        public DateTime GeneradoEl { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }

        public int DeliveryId { get; set; }
        public string DeliveryNombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int Dni { get; set; }

        public List<HistorialDeliveryItemDTO> Pedidos { get; set; } = new();

        public int TotalPedidos => Pedidos.Count;
        public int Entregados => Pedidos.Count(p => p.Estado == EstadoPedido.Entregado);
        public int Cancelados => Pedidos.Count(p => p.Estado == EstadoPedido.Cancelado);

        public decimal MontoEntregado => Pedidos
            .Where(p => p.Estado == EstadoPedido.Entregado)
            .Sum(p => p.PrecioTotal);

        public double? PromedioCalificacion
        {
            get
            {
                var notas = Pedidos.Where(p => p.CalificacionDelivery.HasValue)
                                   .Select(p => p.CalificacionDelivery!.Value)
                                   .ToList();
                return notas.Count == 0 ? null : notas.Average();
            }
        }
    }
}