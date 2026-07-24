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
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository deliveryRepository;
        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            this.deliveryRepository = deliveryRepository;
        }

        public async Task<DeliveryDTO> AddAsync(DeliveryDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre) || dto.Nombre.Length < 2 || dto.Nombre.Length > 50)
                throw new ArgumentException("El nombre es obligatorio y debe tener entre 2 y 50 caracteres.");
            if (string.IsNullOrWhiteSpace(dto.Apellido) || dto.Apellido.Length < 2 || dto.Apellido.Length > 50)
                throw new ArgumentException("El apellido es obligatorio y debe tener entre 2 y 50 caracteres.");
            if (string.IsNullOrWhiteSpace(dto.Telefono) || dto.Telefono.Length <= 8 || !dto.Telefono.All(char.IsDigit))
                throw new ArgumentException("El teléfono es obligatorio, debe tener más de 8 dígitos y contener solo números.");
            if (dto.Dni <= 0 || dto.Dni > 99999999)
                throw new ArgumentException("El DNI debe ser mayor a 0 y contener hasta 8 dígitos.");

            if (await deliveryRepository.DniExistsAsync(dto.Dni))
            {
                throw new ArgumentException($"Ya existe un delivery con el Dni '{dto.Dni}'.");
            }

            Delivery delivery = new Delivery(0, dto.Nombre, dto.Apellido, dto.Telefono, dto.Dni);

            await deliveryRepository.AddAsync(delivery);

            dto.IdDelivery = delivery.IdDelivery;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await deliveryRepository.DeleteAsync(id);
        }

        public async Task<DeliveryDTO?> GetAsync(int id)
        {
            Delivery? delivery = await deliveryRepository.GetAsync(id);

            if (delivery == null)
                return null;

            return new DeliveryDTO
            {
                IdDelivery = delivery.IdDelivery,
                Nombre = delivery.Nombre,
                Apellido = delivery.Apellido,
                Telefono = delivery.Telefono,
                Dni = delivery.Dni
            };
        }

        public async Task<IEnumerable<DeliveryDTO>> GetAllAsync()
        {
            var deliveries = await deliveryRepository.GetAllAsync();

            return deliveries.Select(delivery => new DeliveryDTO
            {
                IdDelivery = delivery.IdDelivery,
                Nombre = delivery.Nombre,
                Apellido = delivery.Apellido,
                Telefono = delivery.Telefono,
                Dni = delivery.Dni
            }).ToList();
        }

        public async Task<bool> UpdateAsync(DeliveryDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre) || dto.Nombre.Length < 2 || dto.Nombre.Length > 50)
                throw new ArgumentException("El nombre es obligatorio y debe tener entre 2 y 50 caracteres.");
            if (string.IsNullOrWhiteSpace(dto.Apellido) || dto.Apellido.Length < 2 || dto.Apellido.Length > 50)
                throw new ArgumentException("El apellido es obligatorio y debe tener entre 2 y 50 caracteres.");
            if (string.IsNullOrWhiteSpace(dto.Telefono) || dto.Telefono.Length <= 8 || !dto.Telefono.All(char.IsDigit))
                throw new ArgumentException("El teléfono es obligatorio, debe tener más de 8 dígitos y contener solo números.");
            if (dto.Dni <= 0 || dto.Dni > 99999999)
                throw new ArgumentException("El DNI debe ser mayor a 0 y contener hasta 8 dígitos.");

            // Validar que el Dni no esté duplicado (excluyendo el delivery actual)
            if (await deliveryRepository.DniExistsAsync(dto.Dni, dto.IdDelivery))
            {
                throw new ArgumentException($"Ya existe otro delivery con el Dni '{dto.Dni}'.");
            }

            var existing = await deliveryRepository.GetAsync(dto.IdDelivery);
            if (existing == null)
                return false;

            Delivery delivery = new Delivery(dto.IdDelivery, dto.Nombre, dto.Apellido, dto.Telefono, dto.Dni);
            return await deliveryRepository.UpdateAsync(delivery);
        }
    }
}