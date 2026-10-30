using Domain.Model.Reportes.Admin;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;

namespace Application.Services.Reportes
{
    public class DeliveryReporteDocument : IDocument
    {
        private readonly DeliveryReporteData _data;

        public DeliveryReporteDocument(DeliveryReporteData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public DocumentMetadata GetMetadata() => new()
        {
            Title = $"Reporte de Delivery - {_data.DeliveryNombre}",
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
                        c, "Reporte de Delivery", _data.Filtros, _data.GeneradoEl));

                    col.Item().Element(ComponerFichaRepartidor);

                    col.Item().Row(row =>
                    {
                        row.Spacing(10);
                        row.RelativeItem().Element(c => ReporteEstilo.Tarjeta(c, "PEDIDOS ASIGNADOS", _data.TotalPedidos.ToString()));
                        row.RelativeItem().Element(c => ReporteEstilo.Tarjeta(c, "ENTREGADOS", _data.Entregados.ToString()));
                        row.RelativeItem().Element(c => ReporteEstilo.Tarjeta(c, "CANCELADOS", _data.Cancelados.ToString()));
                        row.RelativeItem().Element(c => ReporteEstilo.Tarjeta(c, "MONTO ENTREGADO", ReporteEstilo.Moneda(_data.MontoEntregado)));
                        row.RelativeItem().Element(c => ReporteEstilo.Tarjeta(c, "CALIFICACIÓN PROMEDIO", ReporteEstilo.Promedio(_data.PromedioCalificacion)));
                    });

                    if (_data.Filas.Count == 0)
                        col.Item().Element(c => ReporteEstilo.SinDatos(c, "El repartidor no tiene pedidos en el período seleccionado."));
                    else
                        col.Item().Element(ComponerTabla);
                });

                page.Footer().Element(ReporteEstilo.ComponerPie);
            });
        }

        private void ComponerFichaRepartidor(IContainer container)
        {
            container.Border(1).BorderColor(ReporteEstilo.Borde).Padding(10).Row(row =>
            {
                row.RelativeItem().Column(c =>
                {
                    c.Item().Text("REPARTIDOR").FontSize(8).SemiBold().FontColor(ReporteEstilo.Gris);
                    c.Item().Text(_data.DeliveryNombre).FontSize(14).Bold();
                });
                row.RelativeItem().Column(c =>
                {
                    c.Item().Text("TELÉFONO").FontSize(8).SemiBold().FontColor(ReporteEstilo.Gris);
                    c.Item().Text(_data.Telefono).FontSize(11);
                });
                row.RelativeItem().Column(c =>
                {
                    c.Item().Text("DNI").FontSize(8).SemiBold().FontColor(ReporteEstilo.Gris);
                    c.Item().Text(_data.Dni.ToString()).FontSize(11);
                });
            });
        }

        private void ComponerTabla(IContainer container)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(cols =>
                {
                    cols.ConstantColumn(40);   // # pedido
                    cols.RelativeColumn(1.4f); // Fecha
                    cols.RelativeColumn(2f);   // Cliente
                    cols.RelativeColumn(2.6f); // Dirección
                    cols.RelativeColumn(1f);   // Estado
                    cols.RelativeColumn(0.8f); // Calificación
                    cols.RelativeColumn(1.2f); // Total
                });

                table.Header(header =>
                {
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).Text("#");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).Text("Fecha");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).Text("Cliente");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).Text("Dirección");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).Text("Estado");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).AlignCenter().Text("Calif.");
                    header.Cell().Element(ReporteEstilo.CeldaEncabezado).AlignRight().Text("Total");
                });

                for (var i = 0; i < _data.Filas.Count; i++)
                {
                    var fila = _data.Filas[i];
                    var alterna = i % 2 == 1;

                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).Text(fila.PedidoId.ToString());
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).Text(ReporteEstilo.FechaHora(fila.Fecha));
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).Text(fila.Cliente);
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).Text(fila.Direccion);
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna))
                        .Text(fila.Estado).SemiBold().FontColor(ReporteEstilo.ColorEstado(fila.Estado));
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).AlignCenter()
                        .Text(fila.CalificacionDelivery?.ToString() ?? "—");
                    table.Cell().Element(c => ReporteEstilo.CeldaDato(c, alterna)).AlignRight()
                        .Text(ReporteEstilo.Moneda(fila.Total)).SemiBold();
                }
            });
        }
    }
}