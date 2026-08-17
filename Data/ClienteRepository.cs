using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly TPIContext context;

        public ClienteRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Cliente?> GetAsync(int id)
        {
            return await context.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await context.Clientes.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            var existing = await context.Clientes.FindAsync(cliente.Id);
            if (existing != null)
            {
                existing.SetNombre(cliente.Nombre);
                existing.SetApellido(cliente.Apellido);
                existing.SetEmail(cliente.Email);
                existing.SetTelefono(cliente.Telefono);
                existing.SetPassword(cliente.Password);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            var query = context.Clientes.Where(c => c.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<bool> TelefonoExistsAsync(string telefono, int? excludeId = null)
        {
            var query = context.Clientes.Where(c => c.Telefono == telefono);
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }
    }
}
