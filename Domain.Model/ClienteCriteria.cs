using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ClienteCriteria
    {
        public string Texto { get; private set; }

        public ClienteCriteria(string texto)
        {
            Texto = texto ?? string.Empty;
        }
    }
}