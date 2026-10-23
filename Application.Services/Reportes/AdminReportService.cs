using Data;
using Domain.Model;
using Domain.Model.Reportes.Admin;
using DTOs.Reportes.Admin;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Reportes
{
    public class AdminReportService : IAdminReportService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IDeliveryRepository _deliveryRepository;

        static AdminReportService()
        {
            // Licencia Community de QuestPDF.
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public AdminReportService(IPedidoRepository pedidoRepository, IDeliveryRepository deliveryRepository)
        {
            _pedidoRepository = pedidoRepository;
            _deliveryRepository = deliveryRepository;
        }

        // ---------------------------------------------------------------- Pedidos

        public async Task<HistorialPedidosDTO> ObtenerHistorialPedidosAsync(
            DateTime? desde, DateTime? hasta, ModalidadPedido? modalidad, EstadoPedido? estado,
            CancellationToken cancellationToken = default)
        {
            ValidarRango(desde, hasta);

            var pedidos = await _pedidoRepository.GetByRangoAsync(
                desde, hasta, modalidad, estado, deliveryId: null, cancellationToken);

            return new HistorialPedidosDTO
            {
                GeneradoEl = DateTime.Now,
                Desde = desde,
                Hasta = hasta,
                Modalidad = modalidad,
                Estado = estado,
                Pedidos = pedidos.Select(p => new HistorialPedidoItemDTO
                {
                    Id = p.Id,
                    Fecha = p.Fecha,
                    Cliente = p.Cliente != null ? $"{p.Cliente.Nombre} {p.Cliente.Apellido}" : "—",
                    Delivery = p.Delivery != null ? $"{p.Delivery.Nombre} {p.Delivery.Apellido}" : "—",
                    Modalidad = p.Modalidad,
                    Estado = p.Estado,
                    CalificacionPedido = p.CalificacionPedido,
                    PrecioTotal = p.PrecioTotal
                }).ToList()
            };
        }

        public async Task<byte[]> GenerarReportePedidosPdfAsync(
            DateTime? desde, DateTime? hasta, ModalidadPedido? modalidad, EstadoPedido? estado,
            CancellationToken cancellationToken = default)
        {
            var historial = await ObtenerHistorialPedidosAsync(desde, hasta, modalidad, estado, cancellationToken);

            var data = new PedidosReporteData(
                GeneradoEl: historial.GeneradoEl,
                Filtros: DescribirFiltros(desde, hasta, modalidad, estado),
                Filas: historial.Pedidos.Select(p => new PedidoReporteFila(
                    p.Id, p.Fecha, p.Cliente, p.Modalidad.ToString(), p.Estado.ToString(),
                    p.Delivery, p.CalificacionPedido, p.PrecioTotal)).ToList(),
                CantidadPedidos: historial.CantidadPedidos,
                MontoTotal: historial.MontoTotal,
                PromedioCalificacion: historial.PromedioCalificacion,
                CantidadDelivery: historial.Pedidos.Count(
                    p => p.Modalidad == ModalidadPedido.Delivery),
                 CantidadTakeAway: historial.Pedidos.Count(
                     p => p.Modalidad == ModalidadPedido.TakeAway)
            );

            return new PedidosReporteDocument(data).GeneratePdf();
        }

        // ---------------------------------------------------------------- Delivery

        public async Task<HistrorialDeliveryDTO?> ObtenerHistorialDeliveryAsync(
            int deliveryId, DateTime? desde, DateTime? hasta,
            CancellationToken cancellationToken = default)
        {
            ValidarRango(desde, hasta);

            var delivery = await _deliveryRepository.GetAsync(deliveryId);
            if (delivery == null) return null;

            var pedidos = await _pedidoRepository.GetByRangoAsync(
                desde, hasta, modalidad: null, estado: null, deliveryId, cancellationToken);

            return new HistrorialDeliveryDTO
            {
                GeneradoEl = DateTime.Now,
                Desde = desde,
                Hasta = hasta,
                DeliveryId = delivery.IdDelivery,
                DeliveryNombre = $"{delivery.Nombre} {delivery.Apellido}",
                Telefono = delivery.Telefono,
                Dni = delivery.Dni,
                Pedidos = pedidos.Select(p => new HistorialDeliveryItemDTO
                {
                    PedidoId = p.Id,
                    Fecha = p.Fecha,
                    Cliente = p.Cliente != null ? $"{p.Cliente.Nombre} {p.Cliente.Apellido}" : "—",
                    Direccion = string.IsNullOrWhiteSpace(p.Direccion) ? "—" : p.Direccion,
                    Estado = p.Estado,
                    CalificacionDelivery = p.CalificacionDelivery,
                    PrecioTotal = p.PrecioTotal
                }).ToList()
            };
        }

        public async Task<byte[]?> GenerarReporteDeliveryPdfAsync(
            int deliveryId, DateTime? desde, DateTime? hasta,
            CancellationToken cancellationToken = default)
        {
            var historial = await ObtenerHistorialDeliveryAsync(deliveryId, desde, hasta, cancellationToken);
            if (historial == null) return null;

            var data = new DeliveryReporteData(
                GeneradoEl: historial.GeneradoEl,
                Filtros: DescribirPeriodo(desde, hasta),
                DeliveryNombre: historial.DeliveryNombre,
                Telefono: historial.Telefono,
                Dni: historial.Dni,
                Filas: historial.Pedidos.Select(p => new DeliveryReporteFila(
                    p.PedidoId, p.Fecha, p.Cliente, p.Direccion, p.Estado.ToString(),
                    p.CalificacionDelivery, p.PrecioTotal)).ToList(),
                TotalPedidos: historial.TotalPedidos,
                Entregados: historial.Entregados,
                Cancelados: historial.Cancelados,
                MontoEntregado: historial.MontoEntregado,
                PromedioCalificacion: historial.PromedioCalificacion);

            return new DeliveryReporteDocument(data).GeneratePdf();
        }

        // ---------------------------------------------------------------- Helpers

        private static void ValidarRango(DateTime? desde, DateTime? hasta)
        {
            if (desde.HasValue && hasta.HasValue && desde.Value.Date > hasta.Value.Date)
                throw new ArgumentException("La fecha 'desde' no puede ser posterior a la fecha 'hasta'.");
        }

        private static string DescribirPeriodo(DateTime? desde, DateTime? hasta) => (desde, hasta) switch
        {
            (null, null) => "Período: todo el historial",
            (not null, null) => $"Período: desde el {desde:dd/MM/yyyy}",
            (null, not null) => $"Período: hasta el {hasta:dd/MM/yyyy}",
            _ => $"Período: del {desde:dd/MM/yyyy} al {hasta:dd/MM/yyyy}"
        };

        private static string DescribirFiltros(DateTime? desde, DateTime? hasta, ModalidadPedido? modalidad, EstadoPedido? estado) =>
            $"{DescribirPeriodo(desde, hasta)}  ·  Modalidad: {modalidad?.ToString() ?? "Todas"}  ·  Estado: {estado?.ToString() ?? "Todos"}";
    }
}