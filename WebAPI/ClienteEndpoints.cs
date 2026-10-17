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


            

            app.MapPost("/clientes/{id}/change-password", async (int id, DTOs.ChangePasswordRequest req, ClaimsPrincipal user, IClienteService clienteService) =>
            {
                if (!PuedeAdministrarOAccederAlCliente(user, id))
                    return Results.Forbid();

                try
                {
                    await clienteService.ChangePasswordAsync(id, req.CurrentPassword, req.NewPassword);
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("ChangePassword")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status403Forbidden)
            .RequireAuthorization()
            .WithOpenApi();

            app.MapPost("/clientes/{id}/delete", async (int id, DTOs.DeleteAccountRequest req, ClaimsPrincipal user, IClienteService clienteService) =>
            {
                if (!PuedeAdministrarOAccederAlCliente(user, id))
                    return Results.Forbid();

                try
                {
                    // Preguntamos si el usuario actual es Administrador
                    bool esAdmin = user.IsInRole("Administrador");
                    bool bajaLogicaExitosa;

                    if (esAdmin)
                    {
                        // BAJA LÓGICA DE ADMIN: No valida clave, usa el nuevo método
                        bajaLogicaExitosa = await clienteService.DeactivateByAdminAsync(id);
                    }
                    else
                    {
                        // BAJA LÓGICA DE CLIENTE: Valida clave con tu método existente
                        bajaLogicaExitosa = await clienteService.DeleteWithPasswordAsync(id, req.CurrentPassword);
                    }

                    if (!bajaLogicaExitosa) return Results.NotFound();
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { mensaje = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    // Pedido en curso u otra restricción: devolver mensaje claro al cliente
                    return Results.UnprocessableEntity(new { mensaje = ex.Message });
                }
            })
            .WithName("DeactivateCliente") 
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status422UnprocessableEntity)
            .RequireAuthorization()
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
