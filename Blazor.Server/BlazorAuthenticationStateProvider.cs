using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API.Clients;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Server
{
  public sealed class BlazorAuthenticationStateProvider : AuthenticationStateProvider
  {
    private readonly IAuthService authService;

    public BlazorAuthenticationStateProvider(IAuthService authService)
    {
      this.authService = authService;
      this.authService.AuthenticationStateChanged += OnAuthenticationStateChanged;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      var session = authService.CurrentSession;
      if (session == null
          || string.IsNullOrWhiteSpace(session.Token)
          || DateTime.UtcNow >= session.ExpiresAt)
      {
        return Task.FromResult(AnonymousState());
      }

      var token = new JwtSecurityTokenHandler().ReadJwtToken(session.Token);
      var identity = new ClaimsIdentity(token.Claims, "jwt");
      return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
    }

    private void OnAuthenticationStateChanged(bool isAuthenticated)
    {
      NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private static AuthenticationState AnonymousState()
    {
      return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }
  }
}