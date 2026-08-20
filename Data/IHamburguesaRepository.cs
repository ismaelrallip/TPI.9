using Domain.Model;

namespace Data
{
    public interface IHamburguesaRepository
    {
        Task<IEnumerable<Hamburguesa>> GetAllAsync();
        Task<Hamburguesa?> GetByIdAsync(int id);
        Task AddAsync(Hamburguesa hamburguesa);
        Task<bool> UpdateAsync(Hamburguesa hamburguesa);
        Task<bool> DeleteAsync(int id);
    }
}
