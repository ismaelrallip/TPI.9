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
                var response = await authService.LoginAsync(request);
                return response == null ? Results.Unauthorized() : Results.Ok(response);
            })
            .WithName("Login")
            .Produces<LoginResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithOpenApi();
        }
    }
}