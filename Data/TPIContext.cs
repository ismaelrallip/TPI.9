using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Hamburguesa> Hamburguesas { get; set; }
        public DbSet<PrecioDelivery> PreciosDelivery { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public TPIContext(DbContextOptions<TPIContext> options) : base(options)
        {
            // Elimina y crea la base de datos al iniciar la aplicación, solo para fines de desarrollo
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public TPIContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection") 
                    ?? "Server=(localdb)\\mssqllocaldb;Database=TPI_HamburgueseriaDB;Trusted_Connection=True;MultipleActiveResultSets=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Telefono).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(e => e.IdDelivery);
                entity.Property(e => e.IdDelivery).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Telefono).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Dni).IsRequired();
                entity.HasIndex(e => e.Dni).IsUnique();
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Stock).IsRequired();
            });

            modelBuilder.Entity<Hamburguesa>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(200);

                entity.OwnsMany(e => e.Precios, p =>
                {
                    p.Property(x => x.Monto)
                     .HasColumnName("Precio")
                     .HasColumnType("decimal(18,2)")
                     .IsRequired();

                    p.Property(x => x.FechaDesde).HasColumnName("PrecioFechaDesde");
                });

                entity.HasMany(e => e.Ingredientes)
                      .WithMany();
            });

            modelBuilder.Entity<PrecioDelivery>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Monto).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.FechaDesde).IsRequired();
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Fecha).IsRequired();
                entity.Property(e => e.Comentario).HasMaxLength(200);
                entity.Property(e => e.Direccion).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Modalidad).IsRequired();
                entity.Property(e => e.CalificacionPedido);
                entity.Property(e => e.CalificacionDelivery);
                entity.Property(e => e.Estado).IsRequired();
                entity.Property(e => e.ComentarioFinal).HasMaxLength(200);
                entity.Property(e => e.PrecioTotal).IsRequired().HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Cliente)
                      .WithMany(c => c.Pedidos)
                      .HasForeignKey(e => e.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();
                entity.HasOne(e => e.Delivery)
                      .WithMany(d => d.Pedidos)
                      .HasForeignKey(e => e.DeliveryId)
                      .OnDelete(DeleteBehavior.SetNull)
                      .IsRequired(false);
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Cantidad).IsRequired();
                entity.Property(e => e.PrecioUnitario).IsRequired().HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Pedido)
                      .WithMany(p => p.DetallePedido)
                      .HasForeignKey(e => e.PedidoId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
                entity.HasOne(e => e.Hamburguesa)
                      .WithMany()
                      .HasForeignKey(e => e.HamburguesaId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();
            });
        }
    }
}
