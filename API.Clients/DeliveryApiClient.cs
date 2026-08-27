using System.Net.Http.Json;
using DTOs;

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
    }
}
