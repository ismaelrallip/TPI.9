using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // Validar que el Dni no esté duplicado (excluyendo el delicery actual)
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
