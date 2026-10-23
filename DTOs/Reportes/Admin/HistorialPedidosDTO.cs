using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTOs.Reportes.Admin
{
    public class HistorialPedidoItemDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Delivery { get; set; } = string.Empty;
        public ModalidadPedido Modalidad { get; set; }
        public EstadoPedido Estado { get; set; }
        public int? CalificacionPedido { get; set; }
        public decimal PrecioTotal { get; set; }
    }

    public class HistorialPedidosDTO
    {
        public DateTime GeneradoEl { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public ModalidadPedido? Modalidad { get; set; }
        public EstadoPedido? Estado { get; set; }
        public List<HistorialPedidoItemDTO> Pedidos { get; set; } = new();

        public int CantidadPedidos => Pedidos.Count;

        /// <summary>Suma de los pedidos no cancelados.</summary>
        public decimal MontoTotal => Pedidos
            .Where(p => p.Estado != EstadoPedido.Cancelado)
            .Sum(p => p.PrecioTotal);

        public double? PromedioCalificacion
        {
            get
            {
                var notas = Pedidos.Where(p => p.CalificacionPedido.HasValue)
                                   .Select(p => p.CalificacionPedido!.Value)
                                   .ToList();
                return notas.Count == 0 ? null : notas.Average();
            }
        }
    }
}