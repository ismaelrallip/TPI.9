using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class DeliveryCriteria
    {
        public string Texto { get; private set; }

        public DeliveryCriteria(string texto)
        {
            Texto = texto ?? string.Empty;
        }
    }
}