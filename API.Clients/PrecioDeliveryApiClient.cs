using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace API.Clients
{
    public class PrecioDeliveryApiClient : BaseApiClient
    {
        public static async Task<PrecioDeliveryDTO> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("precios-delivery/" + id);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener precio delivery con Id {id}. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<PrecioDeliveryDTO>()
                    ?? throw new InvalidOperationException("La respuesta del servidor no contiene un precio delivery válido.");
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener el precio delivery.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener el precio delivery.", ex); }
        }

        public static async Task<IEnumerable<PrecioDeliveryDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("precios-delivery");
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener la lista de precios delivery. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<PrecioDeliveryDTO>>() ?? Enumerable.Empty<PrecioDeliveryDTO>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener los precios delivery.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener los precios delivery.", ex); }
        }

        public static async Task AddAsync(PrecioDeliveryDTO dto)
        {

            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PostAsJsonAsync("precios-delivery", dto);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear precio delivery. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al crear el precio delivery.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al crear el precio delivery.", ex); }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.DeleteAsync("precios-delivery/" + id);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar precio delivery {id}. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al eliminar el precio delivery.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al eliminar el precio delivery.", ex); }
        }
        public static async Task<IEnumerable<PrecioDeliveryDTO>> GetByCriteriaAsync(DateTime? fechaFiltro = null)
        {
            try
            {
                using var client = await CreateHttpClientAsync();

                string url = "precios-delivery";
                if (fechaFiltro.HasValue)
                {
                    url += $"?fecha={fechaFiltro.Value.ToString("yyyy-MM-dd")}";
                }

                var response = await client.GetAsync(url);
                await HandleAuthorizationAsync(response);

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener la lista de precios. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<PrecioDeliveryDTO>>() ?? Enumerable.Empty<PrecioDeliveryDTO>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder.", ex); }
        }
    }
}
