using Domain.Model;
using Data;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<ClienteDTO> AddAsync(ClienteDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre) || dto.Nombre.Length < 2 || dto.Nombre.Length > 50)
                throw new ArgumentException("El nombre es obligatorio y debe tener entre 2 y 50 caracteres.");
            if (string.IsNullOrWhiteSpace(dto.Apellido) || dto.Apellido.Length < 2 || dto.Apellido.Length > 50)
                throw new ArgumentException("El apellido es obligatorio y debe tener entre 2 y 50 caracteres.");
            if (string.IsNullOrWhiteSpace(dto.Email) || !Regex.IsMatch(dto.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El email es obligatorio y debe tener un formato válido.");
            if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 6)
                throw new ArgumentException("La contraseña es obligatoria y debe tener al menos 6 caracteres.");
            if (string.IsNullOrWhiteSpace(dto.Telefono) || dto.Telefono.Length <= 8 || !dto.Telefono.All(char.IsDigit))
                throw new ArgumentException("El teléfono es obligatorio, debe tener más de 8 dígitos y contener solo números.");

            if (await clienteRepository.EmailExistsAsync(dto.Email))
            {
                throw new ArgumentException($"Ya existe un cliente con el Email '{dto.Email}'.");
            }

            Cliente cliente = new Cliente(0, dto.Nombre, dto.Apellido, dto.Email, dto.Telefono, dto.Password);

            await clienteRepository.AddAsync(cliente);

            dto.Id = cliente.Id;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await clienteRepository.DeleteAsync(id);
        }

        public async Task<ClienteDTO?> GetAsync(int id)
        {
            Cliente? cliente = await clienteRepository.GetAsync(id);

            if (cliente == null)
                return null;

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Password = cliente.Password
            };
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            var clientes = await clienteRepository.GetAllAsync();

            return clientes.Select(cliente => new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Password = cliente.Password
            }).ToList();
        }

        public async Task<bool> UpdateAsync(ClienteDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre) || dto.Nombre.Length < 2 || dto.Nombre.Length > 50)
                throw new ArgumentException("El nombre es obligatorio y debe tener entre 2 y 50 caracteres.");
            if (string.IsNullOrWhiteSpace(dto.Apellido) || dto.Apellido.Length < 2 || dto.Apellido.Length > 50)
                throw new ArgumentException("El apellido es obligatorio y debe tener entre 2 y 50 caracteres.");
            if (string.IsNullOrWhiteSpace(dto.Email) || !Regex.IsMatch(dto.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El email es obligatorio y debe tener un formato válido.");
            if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 6)
                throw new ArgumentException("La contraseña es obligatoria y debe tener al menos 6 caracteres.");
            if (string.IsNullOrWhiteSpace(dto.Telefono) || dto.Telefono.Length <= 8 || !dto.Telefono.All(char.IsDigit))
                throw new ArgumentException("El teléfono es obligatorio, debe tener más de 8 dígitos y contener solo números.");

            // Validar que el email no esté duplicado (excluyendo el cliente actual)
            if (await clienteRepository.EmailExistsAsync(dto.Email, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro cliente con el Email '{dto.Email}'.");
            }

            var existing = await clienteRepository.GetAsync(dto.Id);
            if (existing == null)
                return false;

            Cliente cliente = new Cliente(dto.Id, dto.Nombre, dto.Apellido, dto.Email, dto.Telefono, dto.Password);
            return await clienteRepository.UpdateAsync(cliente);
        }
    }
}