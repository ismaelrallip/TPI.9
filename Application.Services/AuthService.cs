using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using DTOs;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        //Hay un solo administrador, por lo que sus credenciales están hardcodeadas.

        private const string AdminUsername = "admin";
        private const string AdminPassword = "admin";

        private readonly IClienteRepository clienteRepository;

        public AuthService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return null;
            }

            //  Administrador
            if (request.Username.Trim().Equals(AdminUsername, StringComparison.OrdinalIgnoreCase)
                && request.Password == AdminPassword)
            {
                return new LoginResponse { Username = AdminUsername, Role = "Administrador" };
            }

            // Cliente

            // Busca el cliente en la base de datos por email


            var cliente = await clienteRepository.GetByEmailAsync(request.Username.Trim());
            if (cliente == null || cliente.Password != request.Password)
            {
                return null;
            }

            return new LoginResponse { Username = cliente.Email, Role = "Cliente", ClienteId = cliente.Id };
        }
    }
}