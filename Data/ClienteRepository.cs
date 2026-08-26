using Domain.Model;
using Microsoft.Data.SqlClient;
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
        public async Task<IEnumerable<Cliente>> GetByCriteriaAsync(ClienteCriteria criteria)
        {
                const string sql = @"
            SELECT Id, Nombre, Apellido, Email, Telefono, Password
            FROM Clientes
            WHERE Nombre LIKE @SearchTerm
               OR Apellido LIKE @SearchTerm
               OR Email LIKE @SearchTerm
            ORDER BY Nombre, Apellido";

            var clientes = new List<Cliente>();
            string? connectionString = context.Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var cliente = new Cliente(
                    reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("Nombre")),
                    reader.GetString(reader.GetOrdinal("Apellido")),
                    reader.GetString(reader.GetOrdinal("Email")),
                    reader.GetString(reader.GetOrdinal("Telefono")),
                    reader.GetString(reader.GetOrdinal("Password"))
                );
                clientes.Add(cliente);
            }

            return clientes;
        }
        public async Task<Cliente?> GetByEmailAsync(string email)
        {
            return await context.Clientes
                .FirstOrDefaultAsync(c => c.Email.ToLower() == email.ToLower());
        }
    }
}
