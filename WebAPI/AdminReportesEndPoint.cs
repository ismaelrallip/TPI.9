using Application.Services.Reportes;
using Domain.Model;

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

                    return Results.File(pdf, PdfContentType, $"reporte-pedidos-{DateTime.Now:yyyyMMdd-HHmm}.pdf");
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

            group.MapGet("/delivery/{deliveryId:int}", async (
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
                        ? Results.NotFound(new { error = $"El delivery con ID {deliveryId} no existe." })
                        : Results.File(pdf, PdfContentType, $"reporte-delivery-{deliveryId}-{DateTime.Now:yyyyMMdd-HHmm}.pdf");
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