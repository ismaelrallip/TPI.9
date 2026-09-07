using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class HamburguesaEndpoints
    {
        public static void MapHamburguesaEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/hamburguesas").WithTags("Hamburguesas");

            group.MapGet("/", async (IHamburguesaService svc) =>
                Results.Ok(await svc.GetAllAsync()))
            .WithName("GetAllHamburguesas")
            .Produces<List<HamburguesaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            group.MapGet("/{id:int}", async (int id, IHamburguesaService svc) =>
                await svc.GetAsync(id) is HamburguesaDTO dto ? Results.Ok(dto) : Results.NotFound())
            .WithName("GetHamburguesa")
            .Produces<HamburguesaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            group.MapPost("/", async (HamburguesaDTO dto, IHamburguesaService svc) =>
            {
                try
                {
                    var created = await svc.AddAsync(dto);
                    return Results.Created($"/hamburguesas/{created.Id}", created);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddHamburguesa")
            .Produces<HamburguesaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            group.MapPut("/", async (HamburguesaDTO dto, IHamburguesaService svc) =>
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
            .WithName("UpdateHamburguesa")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            group.MapDelete("/{id:int}", async (int id, IHamburguesaService svc) =>
            {
                var deleted = await svc.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteHamburguesa")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}