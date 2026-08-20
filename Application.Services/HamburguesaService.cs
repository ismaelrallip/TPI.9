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
    public class HamburguesaService : IHamburguesaService
    {
        private readonly IHamburguesaRepository hamburguesaRepository;

        public HamburguesaService(IHamburguesaRepository hamburguesaRepository)
        {
            this.hamburguesaRepository = hamburguesaRepository;
        }

        public async Task<HamburguesaDTO> AddAsync(HamburguesaDTO dto)
        {
            Hamburguesa hamburguesa = new Hamburguesa(0, dto.Nombre, dto.Descripcion, dto.Precio, dto.Ingredientes);
            await hamburguesaRepository.AddAsync(hamburguesa);
            dto.Id = hamburguesa.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await hamburguesaRepository.DeleteAsync(id);
        }

        public async Task<HamburguesaDTO?> GetAsync(int id)
        {
            Hamburguesa? hamburguesa = await hamburguesaRepository.GetByIdAsync(id);
            if (hamburguesa == null) return null;

            return new HamburguesaDTO
            {
                Id = hamburguesa.Id,
                Nombre = hamburguesa.Nombre,
                Descripcion = hamburguesa.Descripcion,
                Precio = hamburguesa.Precio,
                Ingredientes = hamburguesa.Ingredientes
            };
        }

        public async Task<IEnumerable<HamburguesaDTO>> GetAllAsync()
        {
            var hamburguesas = await hamburguesaRepository.GetAllAsync();
            return hamburguesas.Select(hamburguesa => new HamburguesaDTO
            {
                Id = hamburguesa.Id,
                Nombre = hamburguesa.Nombre,
                Descripcion = hamburguesa.Descripcion,
                Precio = hamburguesa.Precio,
                Ingredientes = hamburguesa.Ingredientes
            }).ToList();
        }

        public async Task<bool> UpdateAsync(HamburguesaDTO dto)
        {
            var existing = await hamburguesaRepository.GetByIdAsync(dto.Id);
            if (existing == null) return false;

            Hamburguesa hamburguesa = new Hamburguesa(dto.Id, dto.Nombre, dto.Descripcion, dto.Precio, dto.Ingredientes);
            return await hamburguesaRepository.UpdateAsync(hamburguesa);
        }
    }
}
