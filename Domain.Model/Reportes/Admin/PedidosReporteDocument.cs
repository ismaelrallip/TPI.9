using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ScottPlot;
using System;
using System.Collections.Generic;
using Colors = QuestPDF.Helpers.Colors;

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
        double? PromedioCalificacion,
        int CantidadDelivery,
        int CantidadTakeAway);

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
                        row.Spacing(7);
                        row.RelativeItem().Element(c => ReporteEstilo.Tarjeta(c, "CANTIDAD DE PEDIDOS", _data.CantidadPedidos.ToString()));
                        row.RelativeItem().Element(c => ReporteEstilo.Tarjeta(c, "MONTO FACTURADO (SIN CANCELADOS)", ReporteEstilo.Moneda(_data.MontoTotal)));
                        row.RelativeItem().Element(c => ReporteEstilo.Tarjeta(c, "CALIFICACIÓN PROMEDIO", ReporteEstilo.Promedio(_data.PromedioCalificacion)));
                    });

                    col.Item().Element(ComponerGraficoModalidad);

                    if (_data.Filas.Count == 0)
                        col.Item().Element(c => ReporteEstilo.SinDatos(c, "No se encontraron pedidos para los filtros seleccionados."));
                    else
                        col.Item().Element(ComponerTabla);
                });

                page.Footer().Element(ReporteEstilo.ComponerPie);
            });
        }


        private void ComponerItemLeyenda(
            ColumnDescriptor legend,
            string color,
            string modalidad,
            int cantidad,
            int total)
        {
            var porcentaje = total > 0
                ? cantidad * 100.0 / total
                : 0;

            legend.Item().Row(row =>
            {
                row.Spacing(8);

                // Cuadrado de color, sin fondo ni borde exterior
                row.ConstantItem(12)
                    .Height(12)
                    .AlignMiddle()
                    .Background(color);

                row.RelativeItem().Column(details =>
                {
                    details.Item().Text(modalidad)
                        .FontSize(10)
                        .SemiBold()
                        .FontColor(ReporteEstilo.Marron);

                    details.Item().Text(
                        $"{cantidad} pedidos · {porcentaje.ToString("0.0", ReporteEstilo.Cultura)}%")
                        .FontSize(8)
                        .FontColor(ReporteEstilo.Gris);
                });
            });
        }


        private void ComponerGraficoModalidad(IContainer container)
        {
            var total = _data.CantidadDelivery + _data.CantidadTakeAway;

            container.Column(section =>
            {
                section.Spacing(6);

                // Título de la sección
                section.Item()
                    .Text("PEDIDOS POR MODALIDAD")
                    .FontSize(10)
                    .SemiBold()
                    .FontColor(ReporteEstilo.Marron);

                section.Item().Row(row =>
                {
                    row.Spacing(20);

                    // Dona grande a la izquierda
                    row.RelativeItem(1.4f)
                        .Height(145)
                        .AlignCenter()
                        .AlignMiddle()
                        .Element(chart =>
                        {
                            if (total == 0)
                            {
                                chart.AlignCenter()
                                    .AlignMiddle()
                                    .Text("Sin datos de modalidad")
                                    .FontSize(9)
                                    .FontColor(ReporteEstilo.Gris);

                                return;
                            }

                            chart.Svg(size =>
                            {
                                Plot plot = new();

                                var slices = new PieSlice[]
                                {
                                    new()
                                    {
                                        Value = _data.CantidadDelivery,
                                        FillColor = new ScottPlot.Color(
                                            ReporteEstilo.Rojo),
                                        Label = "Delivery"
                                    },
                                    new()
                                    {
                                        Value = _data.CantidadTakeAway,
                                        FillColor = new ScottPlot.Color(
                                            ReporteEstilo.Azul),
                                        Label = "Take Away"
                                    }
                                };

                                var pie = plot.Add.Pie(slices);
                                pie.DonutFraction = 0.35;

                                // Sin leyenda automática ni elementos innecesarios
                                plot.Axes.Frameless();
                                plot.HideGrid();

                                return plot.GetSvgXml(
                                    Math.Max(1, (int)size.Width),
                                    Math.Max(1, (int)size.Height));
                            });
                        });

                    // Leyenda personalizada a la derecha
                    row.RelativeItem(1)
                        .AlignMiddle()
                        .Column(legend =>
                        {
                            legend.Spacing(12);

                            legend.Item().Text("DISTRIBUCIÓN")
                                .FontSize(8)
                                .SemiBold()
                                .FontColor(ReporteEstilo.Gris);

                            ComponerItemLeyenda(
                                legend,
                                ReporteEstilo.Naranja,
                                "Delivery",
                                _data.CantidadDelivery,
                                total);

                            ComponerItemLeyenda(
                                legend,
                                ReporteEstilo.Marron,
                                "Take Away",
                                _data.CantidadTakeAway,
                                total);
                        });
                });
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