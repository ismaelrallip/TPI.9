using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IConfiguration configuration;

        public AuthService(IClienteRepository clienteRepository, IConfiguration configuration)
        {
            this.clienteRepository = clienteRepository;
            this.configuration = configuration;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return null;
            }

            //  Administrador
            var adminUsername = Environment.GetEnvironmentVariable("TPI9_ADMIN_USERNAME");
            var adminPassword = Environment.GetEnvironmentVariable("TPI9_ADMIN_PASSWORD");

            if (!string.IsNullOrWhiteSpace(adminUsername)
                && request.Username.Trim().Equals(adminUsername, StringComparison.OrdinalIgnoreCase)
                && !string.IsNullOrWhiteSpace(adminPassword)
                && request.Password == adminPassword)
            {
                return CreateLoginResponse(adminUsername, "Administrador");
            }

            // Cliente

            // Busca el cliente en la base de datos por email


            var cliente = await clienteRepository.GetByEmailAsync(request.Username.Trim());
            if (cliente == null)
            {
                return null;
            }

            if (!PasswordHasher.Verify(request.Password, cliente.Password))
            {
                if (cliente.Password != request.Password)
                    return null;

                cliente.SetPassword(PasswordHasher.Hash(request.Password));
                await clienteRepository.UpdateAsync(cliente);
            }

            return CreateLoginResponse(cliente.Email, "Cliente", cliente.Id);
        }

        private LoginResponse CreateLoginResponse(string username, string role, int? clienteId = null)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("TPI9_JWT_SECRET_KEY")
                ?? jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            if (string.IsNullOrWhiteSpace(secretKey) || secretKey.Length < 32)
                throw new InvalidOperationException("La clave JWT debe configurarse mediante TPI9_JWT_SECRET_KEY y tener al menos 32 caracteres.");

            if (string.IsNullOrWhiteSpace(issuer) || string.IsNullOrWhiteSpace(audience))
                throw new InvalidOperationException("La configuración JWT requiere Issuer y Audience.");

            var expiresAt = DateTime.UtcNow.AddMinutes(GetExpirationMinutes(jwtSettings));
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, username),
                new(ClaimTypes.Role, role),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            if (clienteId.HasValue)
                claims.Add(new Claim("clienteId", clienteId.Value.ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: expiresAt,
                signingCredentials: credentials);

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = expiresAt,
                Username = username,
                Role = role,
                ClienteId = clienteId
            };
        }

        private static int GetExpirationMinutes(IConfigurationSection jwtSettings)
        {
            return int.TryParse(jwtSettings["ExpirationMinutes"], out var minutes) && minutes > 0
                ? minutes
                : 30;
        }
    }
}