
using Application.Services.Reportes;
using Domain.Model;
using DTOs.Reportes.Admin;

namespace WebAPI
{
    public static class AdminReportesEndpoints
    {
        private const string PdfContentType = "application/pdf";

        public static void MapAdminReportesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/admin/reportes")
                .RequireAuthorization("AdminOnly")
                .WithTags("Reportes Admin");

            // Reporte PDF de todos los pedidos
            group.MapGet("/pedidos", async (
                DateTime? desde,
                DateTime? hasta,
                ModalidadPedido? modalidad,
                EstadoPedido? estado,
                IAdminReportService reportService,
                CancellationToken cancellationToken) =>
            {
                try
                {
                    byte[] pdf = await reportService.GenerarReportePedidosPdfAsync(
                        desde, hasta, modalidad, estado, cancellationToken);

                    return Results.File(
                        pdf,
                        PdfContentType,
                        $"reporte-pedidos-{DateTime.Now:yyyyMMdd-HHmm}.pdf");
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetReportePedidosPdf")
            .Produces(StatusCodes.Status200OK, typeof(byte[]), PdfContentType)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            // Historial de pedidos de un delivery (JSON)
            group.MapGet("/delivery/{deliveryId:int}/historial", async (
                int deliveryId,
                DateTime? desde,
                DateTime? hasta,
                IAdminReportService reportService,
                CancellationToken cancellationToken) =>
            {
                try
                {
                    var historial = await reportService.ObtenerHistorialDeliveryAsync(
                        deliveryId,
                        desde,
                        hasta,
                        cancellationToken);

                    return historial == null
                        ? Results.NotFound(new
                        {
                            error = $"El delivery con ID {deliveryId} no existe."
                        })
                        : Results.Ok(historial);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetHistorialDelivery")
            .Produces<ReporteDeliveryDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // Reporte PDF de un delivery
            group.MapGet("/delivery/{deliveryId:int}", async(
                int deliveryId,
                DateTime? desde,
                DateTime? hasta,
                IAdminReportService reportService,
                CancellationToken cancellationToken) =>
            {
                try
                {
                    byte[]? pdf = await reportService.GenerarReporteDeliveryPdfAsync(
                        deliveryId, desde, hasta, cancellationToken);

                    return pdf == null
                        ? Results.NotFound(new
                        {
                            error = $"El delivery con ID {deliveryId} no existe."
                        })
                        : Results.File(
                            pdf,
                            PdfContentType,
                            $"reporte-delivery-{deliveryId}-{DateTime.Now:yyyyMMdd-HHmm}.pdf"
                        );
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetReporteDeliveryPdf")
            .Produces(StatusCodes.Status200OK, typeof(byte[]), PdfContentType)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
