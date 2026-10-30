using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Reportes.Admin
{
    public record DeliveryReporteFila(
        int PedidoId,
        DateTime Fecha,
        string Cliente,
        string Direccion,
        string Estado,
        int? CalificacionDelivery,
        decimal Total);
}
