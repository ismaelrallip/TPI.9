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
            Cliente.ValidarPassword(dto.Password);

            if (await clienteRepository.EmailExistsAsync(dto.Email))
            {
                throw new ArgumentException($"Ya existe un cliente con el Email '{dto.Email}'.");
            }
            if (await clienteRepository.TelefonoExistsAsync(dto.Telefono))
            {
                throw new ArgumentException($"Ya existe un cliente con el Teléfono '{dto.Telefono}'.");
            }

            Cliente cliente = new Cliente(0, dto.Nombre, dto.Apellido, dto.Email, dto.Telefono, PasswordHasher.Hash(dto.Password!));

            await clienteRepository.AddAsync(cliente);
            dto.Id = cliente.Id;
            dto.Password = null; //  no devuelve la contraseña después de crear
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await clienteRepository.DeleteAsync(id);
        }

        public async Task<ClienteDTO?> GetAsync(int id)
        {
            Cliente? cliente = await clienteRepository.GetAsync(id);
            if (cliente == null) return null;

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Password = null, // no expone contraseña
                Activo = cliente.Activo
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
                Password = null, // no expone contraseña
                Activo = cliente.Activo
            }).ToList();
        }

        public async Task<bool> UpdateAsync(ClienteDTO dto)
        {   
            // Si se envía una contraseña nueva, se valida en texto plano antes de hashearla
            if (!string.IsNullOrEmpty(dto.Password))
                Cliente.ValidarPassword(dto.Password);
            if (await clienteRepository.EmailExistsAsync(dto.Email, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro cliente con el Email '{dto.Email}'.");
            }

            if (await clienteRepository.TelefonoExistsAsync(dto.Telefono, dto.Id))
            {
                throw new ArgumentException($"Ya existe un cliente con el Teléfono '{dto.Telefono}'.");
            }

            var existing = await clienteRepository.GetAsync(dto.Id);
            if (existing == null) return false;

            // Las validaciones de formato saltarán aquí dentro al construirlo

            // Actualizar solo los campos editables
            existing.SetNombre(dto.Nombre);
            existing.SetApellido(dto.Apellido);
            existing.SetEmail(dto.Email);
            existing.SetTelefono(dto.Telefono);

            // Si se proporcionó contraseña (no nula ni vacía), actualizarla; si no, dejar la actual.
            if (!string.IsNullOrEmpty(dto.Password))
            {
                existing.SetPassword(PasswordHasher.Hash(dto.Password));
            }

            // Persistir cambios
            return await clienteRepository.UpdateAsync(existing);
        }
        public async Task ChangePasswordAsync(int id, string currentPassword, string newPassword)
        {
            Cliente.ValidarPassword(newPassword);

            var existing = await clienteRepository.GetAsync(id);
            if (existing == null) throw new InvalidOperationException("Cliente no encontrado.");

            if (!PasswordHasher.Verify(currentPassword, existing.Password))
                throw new ArgumentException("La contraseña actual no es correcta.");

            existing.SetPassword(PasswordHasher.Hash(newPassword));

            await clienteRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteWithPasswordAsync(int id, string currentPassword)
        {
            var existing = await clienteRepository.GetAsync(id);
            if (existing == null) return false;

            if (!PasswordHasher.Verify(currentPassword, existing.Password))
                throw new ArgumentException("La contraseña actual no es correcta.");

            // Comentario que se agregará a pedidos cancelados
            const string comentarioFinal = "Cuenta eliminada por el usuario.";

            return await clienteRepository.DeactivateAsync(id, comentarioFinal);
        }
        public async Task<IEnumerable<ClienteDTO>> GetByCriteriaAsync(ClienteCriteriaDTO criteria)
        {
            var domainCriteria = new ClienteCriteria(criteria.Texto);
            var clientes = await clienteRepository.GetByCriteriaAsync(domainCriteria);

            return clientes.Select(cliente => new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Password = null, // no expone contraseña
                Activo = cliente.Activo
            }).ToList();
        }
    }
}