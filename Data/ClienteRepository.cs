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

       

        public async Task<bool> DeactivateAsync(int id, string comentarioFinal)
        {
            var cliente = await context.Clientes
                .Include(c => c.Pedidos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null) return false;
            if (!cliente.Activo)
            {
                throw new InvalidOperationException("El cliente ya se encuentra dado de baja.");
            }

            // Bloquear si existen pedidos en estados que impiden la baja
            var estadosBloqueo = new[] { EstadoPedido.Pendiente, EstadoPedido.Listo, EstadoPedido.Asignado, EstadoPedido.EnCamino };
            var pedidosBloqueantes = cliente.Pedidos.Where(p => estadosBloqueo.Contains(p.Estado)).ToList();
            if (pedidosBloqueantes.Any())
            {
                throw new InvalidOperationException("No se puede eliminar la cuenta porque existen pedidos en curso.");
            }

            // Para pedidos en EnProceso (Procesando) los cancelamos y agregamos comentario final
            var pedidosParaCancelar = cliente.Pedidos.Where(p => p.Estado == EstadoPedido.EnProceso).ToList();
            foreach (var pedido in pedidosParaCancelar)
            {
                pedido.SetEstado(EstadoPedido.Cancelado);
                var texto = string.IsNullOrWhiteSpace(pedido.ComentarioFinal) ? comentarioFinal : pedido.ComentarioFinal + " | " + comentarioFinal;
                pedido.SetComentarioFinal(texto);
            }

            cliente.SetActivo(false);

            await context.SaveChangesAsync();
            return true;
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
                if (!existing.Activo)
                {
                    throw new InvalidOperationException("No se puede modificar un cliente dado de baja.");
                }
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
            // Agregamos c.Activo para que solo busque duplicados en cuentas activas
            var query = context.Clientes.Where(c => c.Email.ToLower() == email.ToLower() && c.Activo);
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<bool> TelefonoExistsAsync(string telefono, int? excludeId = null)
        {
            // Agregamos c.Activo para que solo busque duplicados en cuentas activas
            var query = context.Clientes.Where(c => c.Telefono == telefono && c.Activo);
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
                .FirstOrDefaultAsync(c => c.Email.ToLower() == email.ToLower() && c.Activo);
        }
    }
}
