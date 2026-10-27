using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI
{
    public static class PrecioDeliveryEndPoint
    {
        public static void MapPrecioDeliveryEndpoints(this WebApplication app)
        {
            app.MapGet("/precios-delivery/{id}", async (int id, IPrecioDeliveryService precioDeliveryService) =>
            {
                PrecioDeliveryDTO? dto = await precioDeliveryService.GetAsync(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetPrecioDelivery")
            .Produces<PrecioDeliveryDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .AllowAnonymous()
            .WithOpenApi();

            // Único endpoint GET para la colección (filtra por fecha si se envía, o trae todo si es nulo)
            app.MapGet("/precios-delivery", async ([FromQuery] DateTime? fecha, IPrecioDeliveryService precioDeliveryService) =>
            {
                var dtos = await precioDeliveryService.GetByCriteriaAsync(fecha);
                return Results.Ok(dtos);
            })
            .WithName("GetPreciosDeliveryByCriteria")
            .Produces<List<PrecioDeliveryDTO>>(StatusCodes.Status200OK)
            .AllowAnonymous()
            .WithOpenApi();

            app.MapDelete("/precios-delivery/{id}", async (int id, IPrecioDeliveryService precioDeliveryService) =>
            {
                var deleted = await precioDeliveryService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeletePrecioDelivery")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();
            app.MapPost("/precios-delivery",
            
            async (PrecioDeliveryDTO dto,IPrecioDeliveryService service) =>
            {
                try
                {
                    var creado = await service.AddAsync(dto);

                    return Results.Created(
                        $"/precios-delivery/{creado.Id}",
                        creado);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
        .WithName("AddPrecioDelivery")
        .Produces<PrecioDeliveryDTO>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .RequireAuthorization("AdminOnly")
        .WithOpenApi();
        }

    }
}