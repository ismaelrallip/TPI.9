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

        public static async Task<IEnumerable<PedidoDTO>> GetByClienteIdAsync(int clienteId)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                var response = await client.GetAsync("pedidos/cliente/" + clienteId);
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
    }
}