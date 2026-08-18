using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IIngredienteService
    {
        Task<IngredienteDTO> AddAsync(IngredienteDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IngredienteDTO?> GetAsync(int id);
        Task<IEnumerable<IngredienteDTO>> GetAllAsync();
        Task<bool> UpdateAsync(IngredienteDTO dto);
    }
}
