using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
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
                await HandleAuthorizationAsync(response);
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
                await HandleAuthorizationAsync(response);
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
                await HandleAuthorizationAsync(response);
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
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar cliente {dto.Id}. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al actualizar el cliente.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al actualizar el cliente.", ex); }
        }

       

        public static async Task<IEnumerable<ClienteDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync($"clientes/criteria?texto={Uri.EscapeDataString(texto)}");
                await HandleAuthorizationAsync(response);
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

        public static async Task RegisterAsync(ClienteDTO dto)
        {
            try
            {
                using var client = CreatePublicHttpClient();

                var response = await client.PostAsJsonAsync("clientes", dto);

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al registrar cliente. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al registrar el cliente.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al registrar el cliente.", ex); }
        }

        public static async Task ChangePasswordAsync(int id, DTOs.ChangePasswordRequest req)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PostAsJsonAsync($"clientes/{id}/change-password", req);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al cambiar la contraseña. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al cambiar la contraseña.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al cambiar la contraseña.", ex); }
        }

        public static async Task DeleteWithPasswordAsync(int id, DTOs.DeleteAccountRequest req)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PostAsJsonAsync($"clientes/{id}/delete", req);
                await HandleAuthorizationAsync(response);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // Intentar parsear un mensaje amigable devuelto por el servidor
                    try
                    {
                        var doc = System.Text.Json.JsonDocument.Parse(content);
                        if (doc.RootElement.TryGetProperty("mensaje", out var msgEl))
                        {
                            throw new InvalidOperationException(msgEl.GetString() ?? content);
                        }
                        if (doc.RootElement.TryGetProperty("error", out var errEl))
                        {
                            throw new InvalidOperationException(errEl.GetString() ?? content);
                        }
                    }
                    catch (System.Text.Json.JsonException)
                    {
                        // no es JSON, continuar
                    }

                    throw new InvalidOperationException($"Error al eliminar la cuenta. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al eliminar la cuenta.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al eliminar la cuenta.", ex); }
        }
        public static async Task DeactivateAsync(int id)
        {
            try
            {
                
                var req = new DTOs.DeleteAccountRequest { CurrentPassword = "" };

                using var client = await CreateHttpClientAsync();
                
                var response = await client.PostAsJsonAsync($"clientes/{id}/delete", req);
                await HandleAuthorizationAsync(response);

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var doc = System.Text.Json.JsonDocument.Parse(content);
                        if (doc.RootElement.TryGetProperty("mensaje", out var msgEl))
                        {
                            throw new InvalidOperationException(msgEl.GetString() ?? content);
                        }
                        if (doc.RootElement.TryGetProperty("error", out var errEl))
                        {
                            throw new InvalidOperationException(errEl.GetString() ?? content);
                        }
                    }
                    catch (System.Text.Json.JsonException)
                    {
                        
                    }

                    throw new InvalidOperationException($"Error al dar de baja la cuenta. Status: {response.StatusCode}. Detalle: {content}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API al dar de baja la cuenta.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al dar de baja la cuenta.", ex); }
        }
    }
}
