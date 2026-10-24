using System.Net.Http.Json;
using Domain.Model;
using DTOs;

namespace API.Clients
{
    public class PedidoApiClient : BaseApiClient
    {
        public static async Task<PedidoDTO> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("pedidos/" + id);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener pedido con Id {id}. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<PedidoDTO>()
                    ?? throw new InvalidOperationException("La respuesta del servidor no contiene un pedido válido.");
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener el pedido.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener el pedido.", ex); }
        }

        public static async Task<IEnumerable<PedidoDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("pedidos");
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener la lista de pedidos. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<PedidoDTO>>() ?? Enumerable.Empty<PedidoDTO>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener los pedidos.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener los pedidos.", ex); }
        }

        public static async Task AddAsync(PedidoDTO dto)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PostAsJsonAsync("pedidos", dto);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear pedido. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al crear el pedido.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al crear el pedido.", ex); }
        }

        public static async Task UpdateAsync(PedidoDTO dto)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PutAsJsonAsync("pedidos", dto);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar pedido {dto.Id}. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al actualizar el pedido.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al actualizar el pedido.", ex); }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.DeleteAsync("pedidos/" + id);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar pedido {id}. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al eliminar el pedido.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al eliminar el pedido.", ex); }
        }

        public static async Task<IEnumerable<PedidoDTO>> GetByClienteIdAsync(int clienteId, DateTime? fecha = null, ModalidadPedido? modalidad = null)
        {
            try
            {
                var parametros = new List<string>();
                if (fecha.HasValue) parametros.Add($"fecha={fecha.Value:yyyy-MM-dd}");
                if (modalidad.HasValue) parametros.Add($"modalidad={modalidad.Value}");
                var url = "pedidos/cliente/" + clienteId + (parametros.Count > 0 ? "?" + string.Join("&", parametros) : string.Empty);

                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync(url);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener pedidos del cliente {clienteId}. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<PedidoDTO>>() ?? Enumerable.Empty<PedidoDTO>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener los pedidos del cliente.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener los pedidos del cliente.", ex); }
        }

        public static async Task<IEnumerable<PedidoDTO>> GetByDeliveryIdAsync(int deliveryId)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("pedidos/delivery/" + deliveryId);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener pedidos del delivery {deliveryId}. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<PedidoDTO>>() ?? Enumerable.Empty<PedidoDTO>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener los pedidos del delivery.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener los pedidos del delivery.", ex); }
        }

        public static async Task<IEnumerable<PedidoDTO>> GetByEstadoAsync(EstadoPedido estado)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("pedidos/estado/" + (int)estado);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener pedidos por estado {estado}. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<PedidoDTO>>() ?? Enumerable.Empty<PedidoDTO>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener los pedidos por estado.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener los pedidos por estado.", ex); }
        }

        // Para los formularios existentes: filtra desde una fecha en adelante
        // y, opcionalmente, por modalidad.
        public static async Task<IEnumerable<PedidoDTO>> GetByFiltroAsync(
            DateTime? fecha,
            ModalidadPedido? modalidad)
        {
            return await GetByFiltroAsync(
                fecha,       // desde
                null,        // sin fecha hasta
                modalidad,
                null);       // sin filtro de estado
        }

        public static async Task<IEnumerable<PedidoDTO>> GetByFiltroAsync(
            DateTime? desde,
            DateTime? hasta,
            ModalidadPedido? modalidad,
            EstadoPedido? estado)
        {
            try
            {
                var parametros = new List<string>();

                if (desde.HasValue)
                {
                    parametros.Add(
                        $"desde={Uri.EscapeDataString(desde.Value.ToString("yyyy-MM-dd"))}");
                }

                if (hasta.HasValue)
                {
                    parametros.Add(
                        $"hasta={Uri.EscapeDataString(hasta.Value.ToString("yyyy-MM-dd"))}");
                }

                if (modalidad.HasValue)
                {
                    parametros.Add(
                        $"modalidad={Uri.EscapeDataString(modalidad.Value.ToString())}");
                }

                if (estado.HasValue)
                {
                    parametros.Add(
                        $"estado={Uri.EscapeDataString(estado.Value.ToString())}");
                }

                string url = "pedidos/filtro";

                if (parametros.Count > 0)
                {
                    url += "?" + string.Join("&", parametros);
                }

                using var client = await CreateHttpClientAsync();
                using var response = await client.GetAsync(url);

                await HandleAuthorizationAsync(response);

                if (!response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    throw new Exception(
                        $"Error al obtener los pedidos filtrados. " +
                        $"Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content
                    .ReadFromJsonAsync<IEnumerable<PedidoDTO>>()
                    ?? Enumerable.Empty<PedidoDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(
                    "No se pudo conectar con la API al obtener los pedidos filtrados.", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception(
                    "La API tardó demasiado en responder al obtener los pedidos filtrados.", ex);
            }
        }


        public static async Task<byte[]> DescargarReportePdfAsync(
            DateTime? desde,
            DateTime? hasta,
            ModalidadPedido? modalidad,
            EstadoPedido? estado)
        {
            try
            {
                var parametros = new List<string>();

                if (desde.HasValue)
                {
                    parametros.Add(
                        $"desde={Uri.EscapeDataString(desde.Value.ToString("yyyy-MM-dd"))}");
                }

                if (hasta.HasValue)
                {
                    parametros.Add(
                        $"hasta={Uri.EscapeDataString(hasta.Value.ToString("yyyy-MM-dd"))}");
                }

                if (modalidad.HasValue)
                {
                    parametros.Add(
                        $"modalidad={Uri.EscapeDataString(modalidad.Value.ToString())}");
                }

                if (estado.HasValue)
                {
                    parametros.Add(
                        $"estado={Uri.EscapeDataString(estado.Value.ToString())}");
                }

                string url = "admin/reportes/pedidos";

                if (parametros.Count > 0)
                {
                    url += "?" + string.Join("&", parametros);
                }

                using var client = await CreateHttpClientAsync();
                using var response = await client.GetAsync(url);

                await HandleAuthorizationAsync(response);

                if (!response.IsSuccessStatusCode)
                {
                    string detalle = await response.Content.ReadAsStringAsync();

                    throw new Exception(
                        $"Error al descargar el reporte de pedidos. " +
                        $"Status: {response.StatusCode}. Detalle: {detalle}"
                    );
                }

                byte[] pdf = await response.Content.ReadAsByteArrayAsync();

                if (pdf.Length == 0)
                {
                    throw new InvalidOperationException(
                        "La API devolvió un archivo PDF vacío.");
                }

                return pdf;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(
                    "No se pudo conectar con la API para descargar el reporte.", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception(
                    "La API tardó demasiado en generar el reporte.", ex);
            }
        }
    }
}