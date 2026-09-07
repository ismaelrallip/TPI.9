using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IPrecioDeliveryRepository
    {
        Task AddAsync(PrecioDelivery precioDelivery);
        Task<bool> DeleteAsync(int id);
        Task<PrecioDelivery?> GetAsync(int id);
        Task<IEnumerable<PrecioDelivery>> GetAllAsync();
        Task<bool> UpdateAsync(PrecioDelivery precioDelivery);
    }
}
