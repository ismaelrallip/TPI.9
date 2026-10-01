using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DetallePedidoDTO
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int HamburguesaId { get; set; }
        public string? HamburguesaNombre { get; set; }
        public int PedidoId { get; set; }
    }
}
