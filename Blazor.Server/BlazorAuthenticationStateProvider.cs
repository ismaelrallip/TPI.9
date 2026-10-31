using API.Auth.Blazor.Server;
using API.Clients;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Blazor.Server
{
    public sealed class BlazorAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly BlazorServerAuthService authService;
        private bool sesionRestaurada;

        public BlazorAuthenticationStateProvider(IAuthService authService)
        {
            this.authService = (BlazorServerAuthService?)authService;
            this.authService.AuthenticationStateChanged += _ =>
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Primera vez en este circuito: intentar recuperar la sesión del navegador
            if (authService.CurrentSession == null && !sesionRestaurada)
            {
                sesionRestaurada = await authService.CargarSesionGuardadaAsync();
            }

            var session = authService.CurrentSession;
            if (session == null || string.IsNullOrWhiteSpace(session.Token) || DateTime.UtcNow >= session.ExpiresAt)
                return AnonymousState();

            try
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(session.Token);
                var identity = new ClaimsIdentity(jwt.Claims, "jwt");
                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch
            {
                return AnonymousState();
            }
        }

        private static AuthenticationState AnonymousState() =>  new(new ClaimsPrincipal(new ClaimsIdentity()));
    }
}