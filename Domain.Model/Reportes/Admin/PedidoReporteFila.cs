using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Reportes.Admin
{
    public record PedidoReporteFila(
        int Id,
        DateTime Fecha,
        string Cliente,
        string Modalidad,
        string Estado,
        string Delivery,
        int? CalificacionPedido,
        decimal Total);
}
