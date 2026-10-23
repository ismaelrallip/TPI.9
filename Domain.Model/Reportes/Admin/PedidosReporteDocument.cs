using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;

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

    public record PedidosReporteData(
        DateTime GeneradoEl,
        string Filtros,
        IReadOnlyList<PedidoReporteFila> Filas,
        int CantidadPedidos,
        decimal MontoTotal,
        double? PromedioCalificacion);

    public class PedidosReporteDocument : IDocument
    {
        private readonly PedidosReporteData _data;

        public PedidosReporteDocument(PedidosReporteData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public DocumentMetadata GetMetadata() => new()
        {
            Title = "Reporte de Pedidos",
            Author = ReporteEstilo.NombreNegocio,
            CreationDate = new DateTimeOffset(_data.GeneradoEl)
        };

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(9).FontColor(ReporteEstilo.Marron));

                page.Content().Column(col =>
                {
                    col.Spacing(12);

                    col.Item().Element(c => ReporteEstilo.ComponerEncabezado(
                        c, "Reporte de Pedidos", _data.Filtros, _data.GeneradoEl));

                    col.Item().Row(row =>
                    {
                        row.Spacing(10);
                        row.RelativeItem().Element(c => ReporteEstilo.Tarjeta(c, "CANTIDAD DE PEDIDOS", _data.CantidadPedidos.ToString()));
                        row.RelativeItem().Element(c => ReporteEstilo.Tarjeta(c, "MONTO FACTURADO (SIN CANCELADOS)", ReporteEstilo.Moneda(_data.MontoTotal)));
                        row.RelativeItem().Element(c => ReporteEstilo.Tarjeta(c, "CALIFICACIÓN PROMEDIO", ReporteEstilo.Promedio(_data.PromedioCalificacion)));
                    });

                    if (_data.Filas.Count == 0)
                        col.Item().Element(c => ReporteEstilo.SinDatos(c, "No se encontraron pedidos para los filtros seleccionados."));
                    else
                        col.Item().Element(ComponerTabla);
                });

                page.Footer().Element(ReporteEstilo.ComponerPie);
            });
        }

        private void ComponerTabla(IContainer container)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(cols =>
                {
                    cols.ConstantColumn(40);   // #
                    cols.RelativeColumn(1.4f); // Fecha
                    cols.RelativeColumn(2f);   // Cliente
                    cols.RelativeColumn(1f);   // Modalidad
                    cols.RelativeColumn(1f);   // Estado
                    cols.RelativeColumn(2f);   // Delivery
                    cols.RelativeColumn(0.8f); // Calificación
                    cols.RelativeColumn(1.2f); // Total
                });

                table.Header(header =>
                {
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).Text("#");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).Text("Fecha");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).Text("Cliente");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).Text("Modalidad");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).Text("Estado");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).Text("Delivery");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).AlignCenter().Text("Calif.");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).AlignRight().Text("Total");
                });

                for (var i = 0; i < _data.Filas.Count; i++)
                {
                    var fila = _data.Filas[i];
                    var alterna = i % 2 == 1;

                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).Text(fila.Id.ToString());
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).Text(ReporteEstilo.FechaHora(fila.Fecha));
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).Text(fila.Cliente);
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).Text(fila.Modalidad);
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna))
                        .Text(fila.Estado).SemiBold().FontColor(ReporteEstilo.ColorEstado(fila.Estado));
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).Text(fila.Delivery);
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).AlignCenter()
                        .Text(fila.CalificacionPedido?.ToString() ?? "—");
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).AlignRight()
                        .Text(ReporteEstilo.Moneda(fila.Total)).SemiBold();
                }
            });
        }
    }
}