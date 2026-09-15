using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Json;
using DTOs;

namespace API.Clients
{
    public class AuthApiClient : BaseApiClient
    {
        public static async Task<LoginResponse?> LoginAsync(string username, string password)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.PostAsJsonAsync("login", new LoginRequest { Username = username, Password = password });

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return null;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al iniciar sesión. Status: {response.StatusCode}. Detalle: {content}");
                }

                return await response.Content.ReadFromJsonAsync<LoginResponse>();
            }
            catch (HttpRequestException ex) { throw new Exception("No se pudo conectar con la API para iniciar sesión.", ex); }
            catch (TaskCanceledException ex) { throw new Exception("La API tardó demasiado en responder al iniciar sesión.", ex); }
        }
    }
}