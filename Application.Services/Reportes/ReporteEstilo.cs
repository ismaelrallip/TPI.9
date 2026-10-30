using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Globalization;

namespace Application.Services.Reportes
{
    internal static class ReporteEstilo
    {
        public const string NombreNegocio = "HAMBURGUESERÍA";

        // --- PALETA BLAZOR PRINCIPAL ---
        public const string AzulMarino = "#0B1536";   // Azul oscuro elegante para encabezados
        public const string AzulGrafico = "#2563EB";  // Azul más brillante exclusivo para el gráfico (legibilidad)
        public const string VioletaOscuro = "#361648"; // Violeta profundo
        public const string Blanco = "#FFFFFF";
        public const string GrisFondo = "#F8F9FA";
        public const string GrisBorde = "#E5E7EB";
        public const string GrisTexto = "#4B5563";
        public const string Verde = "#198754";
        public const string Rojo = "#DC3545";

        // --- ALIAS DE COMPATIBILIDAD ---
        public const string Azul = AzulGrafico;       // ¡El gráfico usa este azul claro!
        public const string Borde = GrisBorde;
        public const string Gris = GrisTexto;
        public const string Marron = AzulMarino;      // Los componentes viejos usan el azul oscuro
        public const string Crema = GrisFondo;
        public const string Naranja = VioletaOscuro;

        public static readonly CultureInfo Cultura = new("es-AR");

        public static string Moneda(decimal valor) => valor.ToString("C2", Cultura);
        public static string FechaHora(DateTime fecha) => fecha.ToString("dd/MM/yyyy HH:mm", Cultura);
        public static string Promedio(double? valor) => valor.HasValue ? valor.Value.ToString("0.0", Cultura) : "—";

        public static string ColorEstado(string estado) => estado switch
        {
            "Entregado" or "Activo" => Verde,
            "Cancelado" or "Inactivo" => Rojo,
            _ => VioletaOscuro
        };

        public static void ComponerEncabezado(IContainer container, string titulo, string subtitulo, DateTime generadoEl)
        {
            container.Column(column =>
            {
                // El encabezado sigue usando el Azul Marino oscuro
                column.Item().Background(AzulMarino).Padding(16).Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text(NombreNegocio).FontSize(10).Bold().FontColor(Blanco);
                        c.Item().PaddingTop(2).Text(titulo).FontSize(20).Bold().FontColor(Blanco);
                    });

                    row.AutoItem().AlignBottom().Text($"Generado el {FechaHora(generadoEl)}")
                        .FontSize(8).FontColor(Blanco);
                });

                column.Item().Height(4).Background(VioletaOscuro);
                column.Item().PaddingTop(8).Text(subtitulo).FontSize(9).FontColor(GrisTexto);
            });
        }

        public static void ComponerPie(IContainer container)
        {
            container.BorderTop(0.5f).BorderColor(GrisBorde).PaddingTop(6).Row(row =>
            {
                row.RelativeItem().Text($"{NombreNegocio} · Reporte del Sistema")
                    .FontSize(8).FontColor(GrisTexto);

                row.RelativeItem().AlignRight().Text(t =>
                {
                    t.DefaultTextStyle(x => x.FontSize(8).FontColor(GrisTexto));
                    t.Span("Página ");
                    t.CurrentPageNumber();
                    t.Span(" de ");
                    t.TotalPages();
                });
            });
        }

        public static void Tarjeta(IContainer container, string etiqueta, string valor)
        {
            container.Background(Blanco).Border(1).BorderColor(GrisBorde).Padding(10).Column(col =>
            {
                col.Item().Text(etiqueta).FontSize(8).SemiBold().FontColor(GrisTexto);
                col.Item().PaddingTop(2).Text(valor).FontSize(16).Bold().FontColor(VioletaOscuro);
            });
        }

        public static void SinDatos(IContainer container, string mensaje)
        {
            container.Background(GrisFondo).Border(1).BorderColor(GrisBorde).Padding(24).AlignCenter()
                .Text(mensaje).FontSize(11).FontColor(GrisTexto);
        }

        public static IContainer CeldaEncabezado(IContainer container) =>
            container.Background(AzulMarino)
                .PaddingVertical(6).PaddingHorizontal(5)
                .DefaultTextStyle(x => x.SemiBold().FontColor(Blanco));

        public static IContainer CeldaDato(IContainer container, bool alterna) =>
            container.Background(alterna ? GrisFondo : Blanco)
                .BorderBottom(0.5f).BorderColor(GrisBorde)
                .PaddingVertical(5).PaddingHorizontal(5);
    }
}