using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IHamburguesaService
    {
        Task<HamburguesaDTO> AddAsync(HamburguesaDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<HamburguesaDTO?> GetAsync(int id);
        Task<IEnumerable<HamburguesaDTO>> GetAllAsync();
        Task<bool> UpdateAsync(HamburguesaDTO dto);
    }
}
