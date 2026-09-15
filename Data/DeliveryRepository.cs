using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly TPIContext context;

        public DeliveryRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Delivery delivery)
        {
            context.Deliveries.Add(delivery);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var delivery = await context.Deliveries.FindAsync(id);
            if (delivery != null)
            {
                context.Deliveries.Remove(delivery);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Delivery?> GetAsync(int id)
        {
            return await context.Deliveries.FindAsync(id);
        }

        public async Task<IEnumerable<Delivery>> GetAllAsync()
        {
            return await context.Deliveries.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Delivery delivery)
        {
            var existing = await context.Deliveries.FindAsync(delivery.IdDelivery);
            if (existing != null)
            {
                existing.SetNombre(delivery.Nombre);
                existing.SetApellido(delivery.Apellido);
                existing.SetTelefono(delivery.Telefono);
                existing.SetDni(delivery.Dni);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DniExistsAsync(int dni, int? excludeId = null)
        {
            var query = context.Deliveries.Where(c => c.Dni == dni);
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.IdDelivery != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<bool> TelefonoExistsAsync(string telefono, int? excludeId = null)
        {
            var query = context.Deliveries.Where(c => c.Telefono == telefono);
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.IdDelivery != excludeId.Value);
            }
            return await query.AnyAsync();
        }
        public async Task<IEnumerable<Delivery>> GetByCriteriaAsync(DeliveryCriteria criteria)
        {
            const string sql = @"
            SELECT IdDelivery, Nombre, Apellido, Telefono, Dni
            FROM Deliveries
            WHERE Nombre LIKE @SearchTerm
               OR Apellido LIKE @SearchTerm
               OR Telefono LIKE @SearchTerm
               OR CAST(Dni AS NVARCHAR(20)) LIKE @SearchTerm
            ORDER BY Nombre, Apellido";

            var deliveries = new List<Delivery>();
            string? connectionString = context.Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var delivery = new Delivery(
                    reader.GetInt32(reader.GetOrdinal("IdDelivery")),
                    reader.GetString(reader.GetOrdinal("Nombre")),
                    reader.GetString(reader.GetOrdinal("Apellido")),
                    reader.GetString(reader.GetOrdinal("Telefono")),
                    reader.GetInt32(reader.GetOrdinal("Dni"))
                );
                deliveries.Add(delivery);
            }

            return deliveries;
        }
    }
}
