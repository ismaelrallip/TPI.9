using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class IngredienteEndpoints
    {
        public static void MapIngredienteEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/ingredientes")
                .WithTags("Ingredientes");

            group.MapGet("/", async (IIngredienteService svc) =>
                Results.Ok(await svc.GetAllAsync()))
            .WithName("GetAllIngredientes")
            .Produces<List<IngredienteDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .AllowAnonymous();

            group.MapGet("/{id:int}", async (int id, IIngredienteService svc) =>
                await svc.GetAsync(id) is IngredienteDTO dto ? Results.Ok(dto) : Results.NotFound())
            .WithName("GetIngrediente")
            .Produces<IngredienteDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .AllowAnonymous();

            group.MapGet("/criteria", async (string? texto, IIngredienteService svc) =>
            Results.Ok(await svc.GetByCriteriaAsync(texto ?? string.Empty)))
            .WithName("GetIngredientesByCriteria")
            .Produces<List<IngredienteDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .AllowAnonymous();

            group.MapPost("/", async (IngredienteDTO dto, IIngredienteService svc) =>
            {
                try
                {
                    var created = await svc.AddAsync(dto);
                    return Results.Created($"/ingredientes/{created.Id}", created);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddIngrediente")
            .Produces<IngredienteDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();

            group.MapPut("/", async (IngredienteDTO dto, IIngredienteService svc) =>
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
            .WithName("UpdateIngrediente")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();

            group.MapDelete("/{id:int}", async (int id, IIngredienteService svc) =>
            {
                var deleted = await svc.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteIngrediente")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();

            group.MapGet("/{id:int}/en-uso", async (int id, IIngredienteService svc) =>
            {
                var ingrediente = await svc.GetAsync(id);

                if (ingrediente == null)
                    return Results.NotFound();

                bool estaEnUso = await svc.EstaEnUsoAsync(id);

                return Results.Ok(estaEnUso);
            })
            .WithName("GetIngredienteEnUso")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .RequireAuthorization("AdminOnly")
            .WithOpenApi();
            
        }
    }
}