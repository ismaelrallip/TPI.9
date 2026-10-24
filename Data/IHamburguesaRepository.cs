using Domain.Model;

namespace Data
{
    public interface IHamburguesaRepository
    {
        Task<IEnumerable<Hamburguesa>> GetAllAsync();
        Task<Hamburguesa?> GetByIdAsync(int id);
        Task<IEnumerable<Hamburguesa>> GetByCriteriaAsync(string texto);
        Task AddAsync(Hamburguesa hamburguesa);
        Task<bool> UpdateAsync(Hamburguesa hamburguesa);
        Task<bool> DeactivateAsync(int id, string comentarioFinal);
    }
}