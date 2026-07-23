using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IDeliveryService
    {
        Task<DeliveryDTO> AddAsync(DeliveryDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<DeliveryDTO?> GetAsync(int id);
        Task<IEnumerable<DeliveryDTO>> GetAllAsync();
        Task<bool> UpdateAsync(DeliveryDTO dto);
    }
}
