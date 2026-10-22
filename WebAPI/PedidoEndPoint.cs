using Application.Services;
using Domain.Model;
using DTOs;
using System.Security.Claims;

namespace WebAPI
{
    public static class PedidoEndpoints
    {
        public static void MapPedidoEndpoints(this WebApplication app)
        {
            app.MapGet("/pedidos/{id:int}", async (int id, ClaimsPrincipal user, IPedidoService pedidoService) =>
            {
                PedidoDTO? dto = await pedidoService.GetAsync(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }

                if (!PuedeAccederAlPedido(user, dto))
                {
                    return Results.Forbid();
                }

                return Results.Ok(dto);
            })
            .WithName("GetPedido")
            .Produces<PedidoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status403Forbidden)
            .RequireAuthorization()
            .WithOpenApi();

            app.MapGet("/pedidos", async (IPedidoService pedidoService) =>
            {
                var dtos = await pedidoService.GetAllAsync();
                return Results.Ok(dtos);
            })
            .WithName("GetAllPedidos")
            .Produces<IEnumerable<PedidoDTO>>(StatusCodes.Status200OK)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();

            app.MapPost("/pedidos", async (PedidoDTO dto, ClaimsPrincipal user, IPedidoService pedidoService) =>
            {
                bool esAdmin = user.IsInRole("Administrador");
                bool esClientePropietario = user.IsInRole("Cliente") && TryGetClienteId(user, out var clienteId) && dto.ClienteId == clienteId;

                if (!esAdmin && !esClientePropietario)
                {
                    return Results.Forbid();
                }

                try
                {
                    PedidoDTO pedidoDTO = await pedidoService.AddAsync(dto);
                    return Results.Created($"/pedidos/{pedidoDTO.Id}", pedidoDTO);
                }
                catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPedido")
            .Produces<PedidoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status403Forbidden)
            .RequireAuthorization()
            .WithOpenApi();


            app.MapPut("/pedidos", async (PedidoDTO dto, ClaimsPrincipal user, IPedidoService pedidoService) =>
            {
                // El permiso se controla contra el pedido guardado,
                // No contra el ClienteId que llega en el body, que lo manda quien hace la peticion.
                var pedidoGuardado = await pedidoService.GetAsync(dto.Id);
                if (pedidoGuardado == null)
                {
                    return Results.NotFound();
                }

                if (!PuedeAccederAlPedido(user, pedidoGuardado))
                {
                    return Results.Forbid();
                }

                // Un cliente no puede cambiar el dueño del pedido; el administrador sí 
                if (!user.IsInRole("Administrador"))
                {
                    dto.ClienteId = pedidoGuardado.ClienteId;
                }
                // Capturamos el rol en una variable para reutilizarlo
                
                bool esAdmin = user.IsInRole("Administrador");

                // Un cliente no puede cambiar el dueño del pedido; el administrador sí 
                if (!esAdmin)
                {
                    dto.ClienteId = pedidoGuardado.ClienteId;
                }

                try
                {
                    // Pasamos la variable esAdmin a la nueva firma del método
                    var found = await pedidoService.UpdateAsync(dto, esAdmin);
                    if (!found)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdatePedido")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status403Forbidden)
            .RequireAuthorization()
            .WithOpenApi();

            app.MapDelete("/pedidos/{id:int}", async (int id, IPedidoService pedidoService) =>
            {
                var deleted = await pedidoService.DeleteAsync(id);
                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeletePedido")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();

            app.MapGet("/pedidos/cliente/{clienteId:int}", async (int clienteId, DateTime? fecha, ModalidadPedido? modalidad, ClaimsPrincipal user, IPedidoService pedidoService) =>
            {
                bool esAdmin = user.IsInRole("Administrador");
                bool esClienteAutorizado = user.IsInRole("Cliente") && TryGetClienteId(user, out var authenticatedClienteId) && authenticatedClienteId == clienteId;

                if (!esAdmin && !esClienteAutorizado)
                {
                    return Results.Forbid();
                }

                var dtos = await pedidoService.GetByClienteIdAsync(clienteId, fecha, modalidad);
                return Results.Ok(dtos);
            })
            .WithName("GetPedidosByCliente")
            .Produces<List<PedidoDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .RequireAuthorization()
            .WithOpenApi();

            app.MapGet("/pedidos/delivery/{deliveryId:int}", async (int deliveryId, ClaimsPrincipal user, IPedidoService pedidoService) =>
            {
                if (!user.IsInRole("Administrador"))
                {
                    return Results.Forbid();
                }

                var dtos = await pedidoService.GetByDeliveryIdAsync(deliveryId);
                return Results.Ok(dtos);
            })
            .WithName("GetPedidosByDelivery")
            .Produces<List<PedidoDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();

            app.MapGet("/pedidos/estado/{estado:int}", async (int estado, IPedidoService pedidoService) =>
            {
                var dtos = await pedidoService.GetByEstadoAsync((EstadoPedido)estado);
                return Results.Ok(dtos);
            })
            .WithName("GetPedidosByEstado")
            .Produces<List<PedidoDTO>>(StatusCodes.Status200OK)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();
            
            app.MapGet("/pedidos/filtro", async (DateTime? fecha, ModalidadPedido? modalidad, IPedidoService pedidoService) =>
            {
                var dtos = await pedidoService.GetByFiltroAsync(fecha, modalidad);
                return Results.Ok(dtos);
            })
            .WithName("GetPedidosByFiltro")
            .Produces<IEnumerable<PedidoDTO>>(StatusCodes.Status200OK)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();
        }

        private static bool TryGetClienteId(ClaimsPrincipal user, out int clienteId)
        {
            return int.TryParse(user.FindFirstValue("clienteId"), out clienteId) && clienteId > 0;
        }

        private static bool PuedeAccederAlPedido(ClaimsPrincipal user, PedidoDTO pedido)
        {
            if (user.IsInRole("Administrador")) return true;

            if (user.IsInRole("Cliente") && TryGetClienteId(user, out var clienteId))
                return pedido.ClienteId == clienteId;

            return false;
        }
    }
}