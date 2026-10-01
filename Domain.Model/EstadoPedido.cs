using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public enum EstadoPedido
    {
        Pendiente,
        EnProceso,
        Listo,
        Asignado,
        EnCamino,
        Entregado,
        Cancelado
    }
}
