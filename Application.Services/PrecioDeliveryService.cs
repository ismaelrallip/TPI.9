using Domain.Model;
using Data;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Application.Services
{
    public class PrecioDeliveryService : IPrecioDeliveryService
    {
        private readonly IPrecioDeliveryRepository precioDeliveryRepository;

        public PrecioDeliveryService(IPrecioDeliveryRepository precioDeliveryRepository)
        {
            this.precioDeliveryRepository = precioDeliveryRepository;
        }

        public async Task<PrecioDeliveryDTO> AddAsync(PrecioDeliveryDTO dto)
        {
            PrecioDelivery precioDelivery = new PrecioDelivery(dto.FechaDesde, dto.Monto);
            await precioDeliveryRepository.AddAsync(precioDelivery);
            dto.Id = precioDelivery.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await precioDeliveryRepository.DeleteAsync(id);
        }

        public async Task<PrecioDeliveryDTO?> GetAsync(int id)
        {
            PrecioDelivery? precioDelivery = await precioDeliveryRepository.GetAsync(id);
            if (precioDelivery == null) return null;

            return new PrecioDeliveryDTO
            {
                Id = precioDelivery.Id,
                FechaDesde = precioDelivery.FechaDesde,
                Monto = precioDelivery.Monto
            };
        }

        public async Task<IEnumerable<PrecioDeliveryDTO>> GetAllAsync()
        {
            var preciosDelivery = await precioDeliveryRepository.GetAllAsync();
            return preciosDelivery.Select(precioDelivery => new PrecioDeliveryDTO
            {
                Id = precioDelivery.Id,
                FechaDesde = precioDelivery.FechaDesde,
                Monto = precioDelivery.Monto
            }).ToList();
        }

        public async Task<bool> UpdateAsync(PrecioDeliveryDTO dto)
        {
            var existing = await precioDeliveryRepository.GetAsync(dto.Id);
            if (existing == null) return false;

            PrecioDelivery precioDelivery = new PrecioDelivery(dto.FechaDesde, dto.Monto);
            precioDelivery.Id = dto.Id;
            return await precioDeliveryRepository.UpdateAsync(precioDelivery);
        }
    }
}
