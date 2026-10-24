
using API.Clients;
using API.Auth.Blazor.Server;
using Application.Services;
using Blazor.Server.Components;
using Blazor.Server;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Autenticacion de la catedra activa
// un servicio por circuito/navegador
builder.Services.AddScoped<API.Clients.IAuthService, BlazorServerAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, BlazorAuthenticationStateProvider>();

// permite que los ApiClients (estaticos) lleguen al servicio de autenticacion del circuito actual
builder.Services.AddCircuitServicesAccessor();

// Autenticacion para las peticiones HTTP completas .
builder.Services.AddAuthentication(SessionAuthenticationHandler.SchemeName)
    .AddScheme<AuthenticationSchemeOptions, SessionAuthenticationHandler>(SessionAuthenticationHandler.SchemeName, _ => { });
builder.Services.AddAuthorization();

builder.Services.AddScoped<NotificatorService>();
var app = builder.Build();

// ya no se registra una instancia global. Los ApiClients piden el servicio del circuito del usuario actual.
AuthServiceProvider.RegisterResolver(
    () => CircuitServicesAccessor.Current?.GetService<API.Clients.IAuthService>());

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
