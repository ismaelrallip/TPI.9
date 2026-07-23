using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDeliveryRepository
    {
        Task AddAsync(Delivery delivery);
        Task<bool> DeleteAsync(int id);
        Task<Delivery?> GetAsync(int id);
        Task<IEnumerable<Delivery>> GetAllAsync();
        Task<bool> UpdateAsync(Delivery cliente);
        Task<bool> DniExistsAsync(int dni, int? excludeId = null);
    }
}
