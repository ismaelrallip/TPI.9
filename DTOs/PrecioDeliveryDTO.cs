using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PrecioDeliveryDTO
    {
        public int Id { get; set; } 
        public DateTime FechaDesde { get; set; } 
        public decimal Monto { get; set; } = decimal.Zero;
    }
}
