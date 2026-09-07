using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PrecioDelivery
    {
        public int Id { get; set; }
        public DateTime FechaDesde { get; private set; }
        public decimal Monto { get; private set; }

        private PrecioDelivery() { } // Para EF Core
        public PrecioDelivery(DateTime fechaDesde, decimal monto)
        {
            SetFecha(fechaDesde);
            SetValor(monto);
        }
        public void SetFecha(DateTime fechaDesde)
        {
            // Validaciones de la fecha 
            if (fechaDesde > DateTime.Now)
                throw new ArgumentOutOfRangeException(nameof(fechaDesde), "La fecha de inicio del precio del delivery no puede ser futura.");
            FechaDesde = fechaDesde;
        }
        public void SetValor(decimal monto)
        {
            if (monto < 0)
                throw new ArgumentOutOfRangeException(nameof(monto), "El monto del delivery no puede ser negativo.");
            Monto = monto;
        }
    }
}
