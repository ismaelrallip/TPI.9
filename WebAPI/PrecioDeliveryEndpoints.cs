using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class PrecioDeliveryEndpoints
    {
        public static void MapPrecioDeliveryEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/precios-delivery").WithTags("PreciosDelivery");

            group.MapGet("/", async (IPrecioDeliveryService svc) =>
                Results.Ok(await svc.GetAllAsync()))
            .WithName("GetAllPreciosDelivery")
            .Produces<List<PrecioDeliveryDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            group.MapGet("/{id:int}", async (int id, IPrecioDeliveryService svc) =>
                await svc.GetAsync(id) is PrecioDeliveryDTO dto ? Results.Ok(dto) : Results.NotFound())
            .WithName("GetPrecioDelivery")
            .Produces<PrecioDeliveryDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            group.MapPost("/", async (PrecioDeliveryDTO dto, IPrecioDeliveryService svc) =>
            {
                try
                {
                    var created = await svc.AddAsync(dto);
                    return Results.Created($"/precios-delivery/{created.Id}", created);
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

            group.MapPut("/", async (PrecioDeliveryDTO dto, IPrecioDeliveryService svc) =>
            {
                try
                {
                    var updated = await svc.UpdateAsync(dto);
                    return updated ? Results.NoContent() : Results.NotFound();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdatePrecioDelivery")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            group.MapDelete("/{id:int}", async (int id, IPrecioDeliveryService svc) =>
            {
                var deleted = await svc.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeletePrecioDelivery")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}