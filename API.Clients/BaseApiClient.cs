using System.Net.Http.Headers;

namespace API.Clients
{
    public abstract class BaseApiClient
    {
        protected static Task<HttpClient> CreateHttpClientAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(GetBaseUrl());
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return Task.FromResult(client);
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
