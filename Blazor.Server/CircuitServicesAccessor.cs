
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Server
{
    public sealed class CircuitServicesAccessor
    {
        private static readonly AsyncLocal<IServiceProvider?> blazorServices = new();

        
        public static IServiceProvider? Current => blazorServices.Value;

        internal void Set(IServiceProvider? services) => blazorServices.Value = services;
    }

    internal sealed class ServicesAccessorCircuitHandler : CircuitHandler
    {
        private readonly IServiceProvider services;
        private readonly CircuitServicesAccessor accessor;

        public ServicesAccessorCircuitHandler(IServiceProvider services, CircuitServicesAccessor accessor)
        {
            this.services = services;
            this.accessor = accessor;
        }

        public override Func<CircuitInboundActivityContext, Task> CreateInboundActivityHandler(
          Func<CircuitInboundActivityContext, Task> next)
        {
            return async context =>
            {
                accessor.Set(services);
                try
                {
                    await next(context);
                }
                finally
                {
                    accessor.Set(null);
                }
            };
        }
    }

    public static class CircuitServicesServiceCollectionExtensions
    {
        public static IServiceCollection AddCircuitServicesAccessor(this IServiceCollection services)
        {
            services.AddScoped<CircuitServicesAccessor>();
            services.AddScoped<CircuitHandler, ServicesAccessorCircuitHandler>();
            return services;
        }
    }
}