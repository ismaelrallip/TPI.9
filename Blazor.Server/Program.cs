using API.Clients;
using API.Auth.Blazor.Server;
using Blazor.Server.Components;
using Blazor.Server;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthorizationCore();

// Autenticaci�n de la c�tedra activa
builder.Services.AddSingleton<IAuthService, BlazorServerAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, BlazorAuthenticationStateProvider>();

var app = builder.Build();

// Registrar el proveedor para los ApiClients
var authService = app.Services.GetRequiredService<IAuthService>();
AuthServiceProvider.Register(authService);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();