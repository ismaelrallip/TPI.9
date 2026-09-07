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
    public class IngredienteService : IIngredienteService
    {
        private readonly IIngredienteRepository ingredienteRepository;

        public IngredienteService(IIngredienteRepository ingredienteRepository)
        {
            this.ingredienteRepository = ingredienteRepository;
        }

        public async Task<IngredienteDTO> AddAsync(IngredienteDTO dto)
        {
            Ingrediente ingrediente = new Ingrediente(0, dto.Nombre, dto.Descripcion, dto.Stock);
            await ingredienteRepository.AddAsync(ingrediente);
            dto.Id = ingrediente.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await ingredienteRepository.DeleteAsync(id);
        }

        public async Task<IngredienteDTO?> GetAsync(int id)
        {
            Ingrediente? ingrediente = await ingredienteRepository.GetAsync(id);
            if (ingrediente == null) return null;

            return new IngredienteDTO
            {
                Id = ingrediente.Id,
                Nombre = ingrediente.Nombre,
                Descripcion = ingrediente.Descripcion,
                Stock = ingrediente.Stock
            };
        }

        public async Task<IEnumerable<IngredienteDTO>> GetAllAsync()
        {
            var ingredientes = await ingredienteRepository.GetAllAsync();
            return ingredientes.Select(ingrediente => new IngredienteDTO
            {
                Id = ingrediente.Id,
                Nombre = ingrediente.Nombre,
                Descripcion = ingrediente.Descripcion,
                Stock = ingrediente.Stock
            }).ToList();
        }

        public async Task<bool> UpdateAsync(IngredienteDTO dto)
        {
            var existing = await ingredienteRepository.GetAsync(dto.Id);
            if (existing == null) return false;

            Ingrediente ingrediente = new Ingrediente(dto.Id, dto.Nombre, dto.Descripcion, dto.Stock);
            return await ingredienteRepository.UpdateAsync(ingrediente);
        }
    }
}