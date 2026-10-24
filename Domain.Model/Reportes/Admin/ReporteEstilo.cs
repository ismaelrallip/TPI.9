using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Globalization;

namespace Domain.Model.Reportes.Admin
{
    /// <summary>
    /// Paleta y componentes visuales compartidos por los reportes PDF del administrador.
    /// </summary>
    internal static class ReporteEstilo
    {
        public const string NombreNegocio = "HAMBURGUESERÍA";
        public const string Naranja = "#E8590C";
        public const string Marron = "#3B2314";
        public const string Crema = "#FFF4E6";
        public const string Borde = "#F1D9BF";
        public const string Gris = "#6B6B6B";
        public const string Verde = "#2B8A3E";
        public const string Rojo = "#C92A2A";
        public const string Azul = "#1C7ED6";

        public static readonly CultureInfo Cultura = new("es-AR");

        public static string Moneda(decimal valor) => valor.ToString("C2", Cultura);
        public static string FechaHora(DateTime fecha) => fecha.ToString("dd/MM/yyyy HH:mm", Cultura);
        public static string Promedio(double? valor) => valor.HasValue ? valor.Value.ToString("0.0", Cultura) : "—";

        public static string ColorEstado(string estado) => estado switch
        {
            "Entregado" => Verde,
            "Cancelado" => Rojo,
            _ => Marron
        };

        public static void ComponerEncabezado(IContainer container, string titulo, string subtitulo, DateTime generadoEl)
        {
            container.Column(column =>
            {
                column.Item().Background(Marron).Padding(16).Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text(NombreNegocio).FontSize(10).Bold().FontColor(Naranja);
                        c.Item().PaddingTop(2).Text(titulo).FontSize(20).Bold().FontColor(Colors.White);
                    });

                    row.AutoItem().AlignBottom().Text($"Generado el {FechaHora(generadoEl)}")
                        .FontSize(8).FontColor(Colors.White);
                });

                column.Item().Height(4).Background(Naranja);
                column.Item().PaddingTop(8).Text(subtitulo).FontSize(9).FontColor(Gris);
            });
        }

        public static void ComponerPie(IContainer container)
        {
            container.BorderTop(0.5f).BorderColor(Borde).PaddingTop(6).Row(row =>
            {
                row.RelativeItem().Text($"{NombreNegocio} · Reporte administrativo")
                    .FontSize(8).FontColor(Gris);

                row.RelativeItem().AlignRight().Text(t =>
                {
                    t.DefaultTextStyle(x => x.FontSize(8).FontColor(Gris));
                    t.Span("Página ");
                    t.CurrentPageNumber();
                    t.Span(" de ");
                    t.TotalPages();
                });
            });
        }

        public static void Tarjeta(IContainer container, string etiqueta, string valor)
        {
            container.Background(Crema).Border(1).BorderColor(Borde).Padding(10).Column(col =>
            {
                col.Item().Text(etiqueta).FontSize(8).SemiBold().FontColor(Gris);
                col.Item().PaddingTop(2).Text(valor).FontSize(16).Bold().FontColor(Naranja);
            });
        }

        public static void SinDatos(IContainer container, string mensaje)
        {
            container.Background(Crema).Border(1).BorderColor(Borde).Padding(24).AlignCenter()
                .Text(mensaje).FontSize(11).FontColor(Gris);
        }

        public static IContainer CeldaEncabezado(IContainer container) =>
            container.Background(Naranja)
                .PaddingVertical(6).PaddingHorizontal(5)
                .DefaultTextStyle(x => x.SemiBold().FontColor(Colors.White));

        public static IContainer CeldaDato(IContainer container, bool alterna) =>
            container.Background(alterna ? Crema : Colors.White)
                .BorderBottom(0.5f).BorderColor(Borde)
                .PaddingVertical(5).PaddingHorizontal(5);
    }
}