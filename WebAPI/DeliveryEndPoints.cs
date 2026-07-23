using Application.Services;
using DTOs;

namespace WebAPI
{
    // basicamente lo minsmo que ClienteEndpoints pero cambie cliente -> delivery, clientes -> deliveries
    public static class DeliveryEndPoints
    {
        public static void MapDeliveryEndpoints(this WebApplication app)
        {
            app.MapGet("/delivery/{id}", async (int id, IDeliveryService deliveryService) =>
            {
                DeliveryDTO? dto = await deliveryService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetDelivery")
            .Produces<DeliveryDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/delivery", async (IDeliveryService deliveryService) =>
            {
                var dtos = await deliveryService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllDeliveries")
            .Produces<List<DeliveryDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/deliveries", async (DeliveryDTO dto, IDeliveryService deliveryService) =>
            {
                try
                {
                    DeliveryDTO deliveryDTO = await deliveryService.AddAsync(dto);

                    return Results.Created($"/deliveries/{deliveryDTO.IdDelivery}", deliveryDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddDelivery")
            .Produces<DeliveryDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/deliveries", async (DeliveryDTO dto, IDeliveryService deliveryService) =>
            {
                try
                {
                    var found = await deliveryService.UpdateAsync(dto);

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
            .WithName("UpdateDelivery")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/deliveries/{id}", async (int id, IDeliveryService deliveryService) =>
            {
                var deleted = await deliveryService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteDelivery")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // comentado ya que se elimino el otro criteria, revisar luego
            /*
            app.MapGet("/deliveries/criteria", async (string texto, IDeliveryService deliveryService) =>
            {
                try
                {
                    var criteria = new DeliveryCriteriaDTO { Texto = texto };
                    var deliveries = await deliveryService.GetByCriteriaAsync(criteria);
                    return Results.Ok(deliveries);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetDeliveriesByCriteria")
            .WithOpenApi();
            */
        }
    }
}