using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Reportes.Admin
{
    public record PedidosReporteData(
        DateTime GeneradoEl,
        string Filtros,
        IReadOnlyList<PedidoReporteFila> Filas,
        int CantidadPedidos,
        decimal MontoTotal,
        double? PromedioCalificacion,
        int CantidadDelivery,
        int CantidadTakeAway);
}
