using Application.Services;
using Domain.Model;
using DTOs;

namespace WebAPI
{
    public static class PedidoEndpoints
    {
        public static void MapPedidoEndpoints(this WebApplication app)
        {
            app.MapGet("/pedidos/{id:int}", async (int id, IPedidoService pedidoService) =>
            {
                PedidoDTO? dto = await pedidoService.GetAsync(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetPedido")
            .Produces<PedidoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/pedidos", async (IPedidoService pedidoService) =>
            {
                var dtos = await pedidoService.GetAllAsync();
                return Results.Ok(dtos);
            })
            .WithName("GetAllPedidos")
            .Produces<List<PedidoDTO>>(StatusCodes.Status200OK)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();

            app.MapPost("/pedidos", async (PedidoDTO dto, IPedidoService pedidoService) =>
            {
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
            .WithOpenApi();

            app.MapPut("/pedidos", async (PedidoDTO dto, IPedidoService pedidoService) =>
            {
                try
                {
                    var found = await pedidoService.UpdateAsync(dto);
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

            app.MapGet("/pedidos/cliente/{clienteId:int}", async (int clienteId, IPedidoService pedidoService) =>
            {
                var dtos = await pedidoService.GetByClienteIdAsync(clienteId);
                return Results.Ok(dtos);
            })
            .WithName("GetPedidosByCliente")
            .Produces<List<PedidoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/pedidos/delivery/{deliveryId:int}", async (int deliveryId, IPedidoService pedidoService) =>
            {
                var dtos = await pedidoService.GetByDeliveryIdAsync(deliveryId);
                return Results.Ok(dtos);
            })
            .WithName("GetPedidosByDelivery")
            .Produces<List<PedidoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/pedidos/estado/{estado:int}", async (int estado, IPedidoService pedidoService) =>
            {
                var dtos = await pedidoService.GetByEstadoAsync((EstadoPedido)estado);
                return Results.Ok(dtos);
            })
            .WithName("GetPedidosByEstado")
            .Produces<List<PedidoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}