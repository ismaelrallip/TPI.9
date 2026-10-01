using WebAPI;
using Application.Services;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

DotNetEnv.Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header. Ejemplo: Bearer {token}",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Entity Framework Context
builder.Services.AddDbContext<TPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var jwtSecretKey = Environment.GetEnvironmentVariable("TPI9_JWT_SECRET_KEY")
    ?? jwtSettings["SecretKey"];
var jwtIssuer = jwtSettings["Issuer"];
var jwtAudience = jwtSettings["Audience"];

if (string.IsNullOrWhiteSpace(jwtSecretKey) || jwtSecretKey.Length < 32)
    throw new InvalidOperationException("La clave JWT debe configurarse mediante TPI9_JWT_SECRET_KEY y tener al menos 32 caracteres.");

if (string.IsNullOrWhiteSpace(jwtIssuer) || string.IsNullOrWhiteSpace(jwtAudience))
    throw new InvalidOperationException("La configuración JWT requiere Issuer y Audience.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,
            ValidateAudience = true,
            ValidAudience = jwtAudience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Administrador"));
    options.AddPolicy("ClienteOnly", policy => policy.RequireRole("Cliente"));
    options.FallbackPolicy = options.DefaultPolicy;
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Add Dependency Injection
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();

builder.Services.AddScoped<IHamburguesaRepository, HamburguesaRepository>();
builder.Services.AddScoped<IHamburguesaService, HamburguesaService>();

builder.Services.AddScoped<IIngredienteRepository, IngredienteRepository>();
builder.Services.AddScoped<IIngredienteService, IngredienteService>();

builder.Services.AddScoped<IPrecioDeliveryRepository, PrecioDeliveryRepository>();
builder.Services.AddScoped<IPrecioDeliveryService, PrecioDeliveryService>();

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

builder.Services.AddScoped<IAuthService, AuthService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS antes de mapear endpoints
app.UseCors("DevCors");

app.UseAuthentication();
app.UseAuthorization();

// HTTPS redirection en todos los entornos
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Map endpoints
app.MapClienteEndpoints();
app.MapDeliveryEndpoints();
app.MapAuthEndpoints();
app.MapHamburguesaEndpoints();
app.MapIngredienteEndpoints();
app.MapPrecioDeliveryEndpoints();
app.MapPedidoEndpoints();

app.Run();
