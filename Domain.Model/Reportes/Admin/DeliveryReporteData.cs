using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Reportes.Admin
{
    public record DeliveryReporteData(
        DateTime GeneradoEl,
        string Filtros,
        string DeliveryNombre,
        string Telefono,
        int Dni,
        IReadOnlyList<DeliveryReporteFila> Filas,
        int TotalPedidos,
        int Entregados,
        int Cancelados,
        decimal MontoEntregado,
        double? PromedioCalificacion);
}
