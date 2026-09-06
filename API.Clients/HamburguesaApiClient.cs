using System.Net.Http.Json;
using DTOs;

namespace API.Clients
{
    public class HamburguesaApiClient : BaseApiClient
    {
        public static async Task<HamburguesaDTO> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("hamburguesas/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener hamburguesa con Id {id}. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<HamburguesaDTO>()
                    ?? throw new InvalidOperationException("La respuesta del servidor no contiene una hamburguesa válida.");
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener la hamburguesa.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener la hamburguesa.", ex); }
        }

        public static async Task<IEnumerable<HamburguesaDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("hamburguesas");
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener la lista de hamburguesas. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<HamburguesaDTO>>() ?? Enumerable.Empty<HamburguesaDTO>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener las hamburguesas.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener las hamburguesas.", ex); }
        }

        public static async Task AddAsync(HamburguesaDTO dto)
        {

            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PostAsJsonAsync("hamburguesas", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear hamburguesa. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al crear la hamburguesa.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al crear la hamburguesa.", ex); }
        }

        public static async Task UpdateAsync(HamburguesaDTO dto)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PutAsJsonAsync("hamburguesas", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar hamburguesa {dto.Nombre}. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al actualizar la hamburguesa.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al actualizar la hamburguesa.", ex); }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.DeleteAsync("hamburguesas/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar hamburguesa {id}. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al eliminar la hamburguesa.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al eliminar la hamburguesa.", ex); }
        }
    }
}
