using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPrecioDeliveryService
    {
        Task<PrecioDeliveryDTO> AddAsync(PrecioDeliveryDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<PrecioDeliveryDTO?> GetAsync(int id);
        Task<IEnumerable<PrecioDeliveryDTO>> GetAllAsync();
        Task<bool> UpdateAsync(PrecioDeliveryDTO dto);

    }
}
