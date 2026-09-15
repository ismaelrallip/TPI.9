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
            
            if (await deliveryRepository.DniExistsAsync(dto.Dni))
            {
                throw new ArgumentException($"Ya existe un delivery con el Dni '{dto.Dni}'.");
            }
            if (await deliveryRepository.TelefonoExistsAsync(dto.Telefono))
            {
                throw new ArgumentException($"Ya existe un delivery con el Teléfono '{dto.Telefono}'.");
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
           
            if (await deliveryRepository.DniExistsAsync(dto.Dni, dto.IdDelivery))
            {
                throw new ArgumentException($"Ya existe otro delivery con el Dni '{dto.Dni}'.");
            }
            if (await deliveryRepository.TelefonoExistsAsync(dto.Telefono, dto.IdDelivery))
            {
                throw new ArgumentException($"Ya existe un delivery con el Teléfono '{dto.Telefono}'.");
            }
            var existing = await deliveryRepository.GetAsync(dto.IdDelivery);
            if (existing == null)
                return false;

            Delivery delivery = new Delivery(dto.IdDelivery, dto.Nombre, dto.Apellido, dto.Telefono, dto.Dni);
            return await deliveryRepository.UpdateAsync(delivery);
        }
        public async Task<IEnumerable<DeliveryDTO>> GetByCriteriaAsync(DeliveryCriteriaDTO criteria)
        {
            var domainCriteria = new DeliveryCriteria(criteria.Texto);
            var deliveries = await deliveryRepository.GetByCriteriaAsync(domainCriteria);

            return deliveries.Select(delivery => new DeliveryDTO
            {
                IdDelivery = delivery.IdDelivery,
                Nombre = delivery.Nombre,
                Apellido = delivery.Apellido,
                Telefono = delivery.Telefono,
                Dni = delivery.Dni
            }).ToList();
        }
    }
}