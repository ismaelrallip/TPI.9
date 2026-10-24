using DTOs;
using DTOs.Reportes.Admin;
using System.Net.Http.Json;

namespace API.Clients
{
    public class DeliveryApiClient : BaseApiClient
    {
        public static async Task<DeliveryDTO> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("deliveries/" + id);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener delivery con Id {id}. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<DeliveryDTO>()
                    ?? throw new InvalidOperationException("La respuesta del servidor no contiene un delivery válido.");
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener el delivery.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener el delivery.", ex); }
        }

        public static async Task<IEnumerable<DeliveryDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("deliveries");
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener la lista de deliveries. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<DeliveryDTO>>() ?? Enumerable.Empty<DeliveryDTO>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener los deliveries.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener los deliveries.", ex); }
        }

        public static async Task AddAsync(DeliveryDTO dto)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PostAsJsonAsync("deliveries", dto);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear delivery. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al crear el delivery.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al crear el delivery.", ex); }
        }

        public static async Task UpdateAsync(DeliveryDTO dto)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PutAsJsonAsync("deliveries", dto);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar delivery {dto.IdDelivery}. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al actualizar el delivery.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al actualizar el delivery.", ex); }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.DeleteAsync("deliveries/" + id);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar delivery {id}. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al eliminar el delivery.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al eliminar el delivery.", ex); }
        }
        public static async Task<IEnumerable<DeliveryDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync($"deliveries/criteria?texto={Uri.EscapeDataString(texto)}");
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al buscar deliveries. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<DeliveryDTO>>() ?? Enumerable.Empty<DeliveryDTO>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al buscar deliveries.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al buscar deliveries.", ex); }
        }

        public static async Task<ReporteDeliveryDTO> ObtenerHistorialAsync(
            int deliveryId,
            DateTime? desde,
            DateTime? hasta)
        {
            try
            {
                var parametros = new List<string>();

                if (desde.HasValue)
                    parametros.Add($"desde={desde.Value:yyyy-MM-dd}");

                if (hasta.HasValue)
                    parametros.Add($"hasta={hasta.Value:yyyy-MM-dd}");

                string url = $"admin/reportes/delivery/{deliveryId}/historial";

                if (parametros.Count > 0)
                    url += "?" + string.Join("&", parametros);

                using var client = await CreateHttpClientAsync();
                using var response = await client.GetAsync(url);

                await HandleAuthorizationAsync(response);

                if (!response.IsSuccessStatusCode)
                {
                    var detalle = await response.Content.ReadAsStringAsync();

                    throw new Exception(
                        $"Error al obtener el historial del delivery. " +
                        $"Status: {response.StatusCode}. Detalle: {detalle}");
                }

                return await response.Content.ReadFromJsonAsync<ReporteDeliveryDTO>()
                    ?? throw new InvalidOperationException(
                        "La API no devolvió un historial válido.");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(
                    "No se pudo conectar con la API para obtener el historial.", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception(
                    "La API tardó demasiado en responder al obtener el historial.", ex);
            }
        }

        public static async Task<byte[]> DescargarReporteDeliveryPdfAsync(
            int deliveryId,
            DateTime? desde,
            DateTime? hasta)
        {
            try
            {
                var parametros = new List<string>();

                if (desde.HasValue)
                    parametros.Add($"desde={desde.Value:yyyy-MM-dd}");

                if (hasta.HasValue)
                    parametros.Add($"hasta={hasta.Value:yyyy-MM-dd}");

                string url = $"admin/reportes/delivery/{deliveryId}";

                if (parametros.Count > 0)
                    url += "?" + string.Join("&", parametros);

                using var client = await CreateHttpClientAsync();
                using var response = await client.GetAsync(url);

                await HandleAuthorizationAsync(response);

                if (!response.IsSuccessStatusCode)
                {
                    var detalle = await response.Content.ReadAsStringAsync();

                    throw new Exception(
                        $"Error al descargar el reporte del delivery. " +
                        $"Status: {response.StatusCode}. Detalle: {detalle}");
                }

                byte[] pdf = await response.Content.ReadAsByteArrayAsync();

                if (pdf.Length == 0)
                    throw new InvalidOperationException(
                        "La API devolvió un PDF vacío.");

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
