
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Blazor.Server
{
    public sealed class SessionAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public const string SchemeName = "Session";

        public SessionAuthenticationHandler(
          IOptionsMonitor<AuthenticationSchemeOptions> options,
          ILoggerFactory logger,
          UrlEncoder encoder) : base(options, logger, encoder)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        // No autenticado: ir al login
        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Redirect("/login");
            return Task.CompletedTask;
        }

        protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Response.Redirect("/login");
            return Task.CompletedTask;
        }
    }
}