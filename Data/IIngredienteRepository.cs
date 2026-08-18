using Domain.Model;

namespace Data
{
    public interface IIngredienteRepository
    {
        Task AddAsync(Ingrediente ingrediente);
        Task<bool> DeleteAsync(int id);
        Task<Ingrediente?> GetAsync(int id);
        Task<IEnumerable<Ingrediente>> GetAllAsync();
        Task<bool> UpdateAsync(Ingrediente ingrediente);
    }
}
