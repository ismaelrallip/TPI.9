using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/login", async (LoginRequest request, IAuthService authService) =>
            {
                try
                {
                    var response = await authService.LoginAsync(request);

                    return response == null ? Results.Unauthorized() : Results.Ok(response);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error durante el login: {ex.Message}");
                }
            })
            .WithName("Login")
            .Produces<LoginResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status500InternalServerError)
            .AllowAnonymous()
            .WithOpenApi();
        }
    }
}