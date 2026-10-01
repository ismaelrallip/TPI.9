using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Comentario { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public ModalidadPedido Modalidad { get; set; }
        public int CalificacionPedido { get; set; }
        public int? CalificacionDelivery { get; set; }
        public EstadoPedido Estado { get; set; }
        public string? ComentarioFinal { get; set; }
        public decimal PrecioTotal { get; set; }
        public int ClienteId { get; set; }
        public string? ClienteNombre { get; set; }
        public int? DeliveryId { get; set; }
        public string? DeliveryNombre { get; set; }
        public List<DetallePedidoDTO> DetallesPedido { get; set; } = new List<DetallePedidoDTO>();
    }
}
