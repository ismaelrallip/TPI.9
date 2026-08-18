using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HamburguesaRepository : IHamburguesaRepository
    {
        private readonly TPIContext context;

        public HamburguesaRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task<List<Hamburguesa>> GetAllAsync()
        {
            return await context.Hamburguesas.ToListAsync();
        }

        public async Task<Hamburguesa> GetByIdAsync(int id)
        {
            return await context.Hamburguesas.FindAsync(id);
        }

        public async Task AddAsync(Hamburguesa hamburguesa)
        {
            await context.Hamburguesas.AddAsync(hamburguesa);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Hamburguesa hamburguesa)
        {
            var existingHamburguesa = await context.Hamburguesas.FindAsync(hamburguesa.Id);
            if (existingHamburguesa == null)
                return;
            existingHamburguesa.SetNombre(hamburguesa.Nombre);
            existingHamburguesa.SetDescripcion(hamburguesa.Descripcion);
            existingHamburguesa.SetIngredientes(hamburguesa.Ingredientes);
            context.Hamburguesas.Update(existingHamburguesa);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hamburguesa = await context.Hamburguesas.FindAsync(id);
            if (hamburguesa != null)
            {
                context.Hamburguesas.Remove(hamburguesa);
                await context.SaveChangesAsync();
            }
        }
    }
}