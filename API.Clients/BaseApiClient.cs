using System.Net.Http.Headers;
using System.Net;

namespace API.Clients
{
    public abstract class BaseApiClient
    {
        static BaseApiClient()
        {
            DotNetEnv.Env.TraversePath().Load();
        }

        protected static async Task<HttpClient> CreateHttpClientAsync()
        {
            var client = CreateConfiguredHttpClient();
            var authService = AuthServiceProvider.Current;
            if (authService == null)
                throw new UnauthorizedAccessException("No hay un servicio de autenticación registrado.");

            await authService.CheckTokenExpirationAsync();
            var token = await authService.GetTokenAsync();
            if (string.IsNullOrWhiteSpace(token))
                throw new SessionExpiredException();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            return client;
        }

        protected static HttpClient CreatePublicHttpClient()
        {
            return CreateConfiguredHttpClient();
        }

        private static HttpClient CreateConfiguredHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(GetBaseUrl()),
                Timeout = TimeSpan.FromSeconds(30)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        protected static async Task HandleAuthorizationAsync(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (AuthServiceProvider.Current != null)
                    await AuthServiceProvider.Current.LogoutAsync();

                throw new SessionExpiredException();
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new UnauthorizedAccessException("El usuario autenticado no tiene permisos para realizar esta operación.");
        }

        private static string GetBaseUrl()
        {
            var envUrl = Environment.GetEnvironmentVariable("TPI_API_BASE_URL");
            if (!string.IsNullOrWhiteSpace(envUrl))
            {
                return envUrl.TrimEnd('/') + "/";
            }

            return "http://localhost:5183/";
        }
    }
}
