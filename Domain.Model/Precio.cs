using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Precio
    {
        public DateTime FechaDesde { get; private set; }
        public decimal Monto { get; private set; }

        public Precio(DateTime fechaDesde, decimal monto) 
        {
            SetFecha(fechaDesde);
            SetValor(monto);
        }

        public void SetFecha(DateTime fechaDesde)
        {
            FechaDesde = fechaDesde;
        }
        public void SetValor(decimal monto) 
        {
            Monto = monto;
        }
    }
}
