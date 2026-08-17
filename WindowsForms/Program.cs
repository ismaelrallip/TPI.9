using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data;
using Application.Services;
using Microsoft.EntityFrameworkCore;

namespace WindowsForms
{
    static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<TPIContext>(options =>
                        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TPI_HamburgueseriaDB;Trusted_Connection=True;MultipleActiveResultSets=true"));

                    services.AddScoped<IClienteRepository, ClienteRepository>();
                    services.AddScoped<IDeliveryRepository, DeliveryRepository>();

                    services.AddScoped<IClienteService, ClienteService>();
                    services.AddScoped<IDeliveryService, DeliveryService>();

                    services.AddTransient<LoginForm>();
                    services.AddTransient<Home>();
                    services.AddTransient<ClienteForm>();
                    services.AddTransient<ClienteDetailForm>();
                    services.AddTransient<DeliveryForm>();
                    services.AddTransient<DeliveryDetailForm>();
                })
                .Build();

            ServiceProvider = host.Services;

            var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                var homeForm = ServiceProvider.GetRequiredService<Home>();
                System.Windows.Forms.Application.Run(homeForm);
            }
        }
    }
}
