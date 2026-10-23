using Domain.Model;
using DTOs.Reportes.Admin;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Reportes
{
    public interface IAdminReportService
    {
        Task<ReportePedidosDTO> ObtenerHistorialPedidosAsync(
            DateTime? desde, DateTime? hasta, ModalidadPedido? modalidad, EstadoPedido? estado,
            CancellationToken cancellationToken = default);

        /// <returns>null si el delivery no existe.</returns>
        Task<ReporteDeliveryDTO?> ObtenerHistorialDeliveryAsync(
            int deliveryId, DateTime? desde, DateTime? hasta,
            CancellationToken cancellationToken = default);

        Task<byte[]> GenerarReportePedidosPdfAsync(
            DateTime? desde, DateTime? hasta, ModalidadPedido? modalidad, EstadoPedido? estado,
            CancellationToken cancellationToken = default);

        /// <returns>null si el delivery no existe.</returns>
        Task<byte[]?> GenerarReporteDeliveryPdfAsync(
            int deliveryId, DateTime? desde, DateTime? hasta,
            CancellationToken cancellationToken = default);
    }
}