using Application.Services;
using DTOs;
using System.Security.Claims;

namespace WebAPI
{
    public static class ClienteEndpoints
    {
        public static void MapClienteEndpoints(this WebApplication app)
        {
            app.MapGet("/clientes/{id:int}", async (int id, ClaimsPrincipal user, IClienteService clienteService) =>
            {
                if (!PuedeAdministrarOAccederAlCliente(user, id))
                    return Results.Forbid();

                ClienteDTO? dto = await clienteService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetCliente")
            .Produces<ClienteDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/clientes", async (IClienteService clienteService) =>
            {
                var dtos = await clienteService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllClientes")
            .Produces<List<ClienteDTO>>(StatusCodes.Status200OK)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();

            app.MapPost("/clientes", async (ClienteDTO dto, IClienteService clienteService) =>
            {
                try
                {
                    ClienteDTO clienteDTO = await clienteService.AddAsync(dto);

                    return Results.Created($"/clientes/{clienteDTO.Id}", clienteDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddCliente")
            .Produces<ClienteDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .AllowAnonymous()
            .WithOpenApi();

            app.MapPut("/clientes", async (ClienteDTO dto, ClaimsPrincipal user, IClienteService clienteService) =>
            {
                if (!PuedeAdministrarOAccederAlCliente(user, dto.Id))
                    return Results.Forbid();

                try
                {
                    var found = await clienteService.UpdateAsync(dto);

                    if (!found)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateCliente")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            app.MapDelete("/clientes/{id}", async (int id, ClaimsPrincipal user, IClienteService clienteService) =>
            {
                if (!PuedeAdministrarOAccederAlCliente(user, id))
                    return Results.Forbid();

                var deleted = await clienteService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteCliente")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/clientes/criteria", async (string texto, IClienteService clienteService) =>
            {
                var criteria = new ClienteCriteriaDTO { Texto = texto };
                var clientes = await clienteService.GetByCriteriaAsync(criteria);
                return Results.Ok(clientes);
            })
            .WithName("GetClientesByCriteria")
            .Produces<List<ClienteDTO>>(StatusCodes.Status200OK)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();

            app.MapGet("/deliveries/criteria", async (string texto, IDeliveryService deliveryService) =>
            {
                var criteria = new DeliveryCriteriaDTO { Texto = texto };
                var deliveries = await deliveryService.GetByCriteriaAsync(criteria);
                return Results.Ok(deliveries);
            })
            .WithName("GetDeliveriesByCriteria")
            .Produces<List<DeliveryDTO>>(StatusCodes.Status200OK)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();
        }

        private static bool TryGetClienteId(ClaimsPrincipal user, out int clienteId)
        {
            return int.TryParse(user.FindFirstValue("clienteId"), out clienteId) && clienteId > 0;
        }

        private static bool PuedeAdministrarOAccederAlCliente(ClaimsPrincipal user, int clienteId)
        {
            return user.IsInRole("Administrador")
                || (user.IsInRole("Cliente")
                    && TryGetClienteId(user, out var authenticatedClienteId)
                    && authenticatedClienteId == clienteId);
        }
    }
}
