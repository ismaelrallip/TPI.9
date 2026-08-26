using System.Net.Http.Json;
using DTOs;

namespace API.Clients
{
    public class ClienteApiClient : BaseApiClient
    {
        public static async Task<ClienteDTO> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("clientes/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener cliente con Id {id}. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<ClienteDTO>()
                    ?? throw new InvalidOperationException("La respuesta del servidor no contiene un cliente válido.");
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener el cliente.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener el cliente.", ex); }
        }

        public static async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("clientes");
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener la lista de clientes. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<ClienteDTO>>() ?? Enumerable.Empty<ClienteDTO>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al obtener los clientes.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al obtener los clientes.", ex); }
        }

        public static async Task AddAsync(ClienteDTO dto)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PostAsJsonAsync("clientes", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear cliente. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al crear el cliente.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al crear el cliente.", ex); }
        }

        public static async Task UpdateAsync(ClienteDTO dto)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PutAsJsonAsync("clientes", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar cliente {dto.Id}. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al actualizar el cliente.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al actualizar el cliente.", ex); }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.DeleteAsync("clientes/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar cliente {id}. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al eliminar el cliente.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al eliminar el cliente.", ex); }
        }
        public static async Task<IEnumerable<ClienteDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync($"clientes/criteria?texto={Uri.EscapeDataString(texto)}");
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al buscar clientes. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<ClienteDTO>>() ?? Enumerable.Empty<ClienteDTO>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al buscar clientes.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al buscar clientes.", ex); }
        }
    }
}
