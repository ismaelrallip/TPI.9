using Domain.Model;

namespace Data
{
    public interface IHamburguesaRepository
    {
        Task<List<Hamburguesa>> GetAllAsync();
        Task<Hamburguesa> GetByIdAsync(int id);
        Task AddAsync(Hamburguesa hamburguesa);
        Task UpdateAsync(Hamburguesa hamburguesa);
        Task DeleteAsync(int id);
    }
}
