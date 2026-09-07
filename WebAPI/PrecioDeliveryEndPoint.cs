using Application.Services;
using DTOs;

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
            .WithOpenApi();

            app.MapGet("/precios-delivery", async (IPrecioDeliveryService precioDeliveryService) =>
            {
                var dtos = await precioDeliveryService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllPreciosDelivery")
            .Produces<List<PrecioDeliveryDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/precios-delivery", async (PrecioDeliveryDTO dto, IPrecioDeliveryService precioDeliveryService) =>
            {
                try
                {
                    PrecioDeliveryDTO precioDeliveryDTO = await precioDeliveryService.AddAsync(dto);
                    return Results.Created($"/precios-delivery/{precioDeliveryDTO.Id}", precioDeliveryDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPrecioDelivery")
            .Produces<PrecioDeliveryDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/precios-delivery", async (PrecioDeliveryDTO dto, IPrecioDeliveryService precioDeliveryService) =>
            {
                try
                {
                    var found = await precioDeliveryService.UpdateAsync(dto);
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
            .WithName("UpdatePrecioDelivery")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
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
            .WithOpenApi();
        }
    }
}
