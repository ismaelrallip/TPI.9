using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly TPIContext context;

        public IngredienteRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Ingrediente ingrediente)
        {
            await context.Ingredientes.AddAsync(ingrediente);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ingrediente = await context.Ingredientes.FindAsync(id);
            if (ingrediente == null)
                return false;

            context.Ingredientes.Remove(ingrediente);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Ingrediente?> GetAsync(int id)
        {
            return await context.Ingredientes.FindAsync(id);
        }

        public async Task<IEnumerable<Ingrediente>> GetAllAsync()
        {
            return await context.Ingredientes.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Ingrediente ingrediente)
        {
            var existingIngrediente = await context.Ingredientes.FindAsync(ingrediente.Id);
            if (existingIngrediente == null)
                return false;
            existingIngrediente.SetNombre(ingrediente.Nombre);
            existingIngrediente.SetDescripcion(ingrediente.Descripcion);
            existingIngrediente.SetStock(ingrediente.Stock);
            context.Ingredientes.Update(existingIngrediente);
            await context.SaveChangesAsync();
            return true;
        }
    }
}   