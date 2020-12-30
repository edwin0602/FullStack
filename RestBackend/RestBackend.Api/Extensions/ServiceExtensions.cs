using Microsoft.Extensions.DependencyInjection;
using RestBackend.Core;
using RestBackend.Core.Services;
using RestBackend.Data;
using RestBackend.Services;

namespace RestBackend.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IVehicleService, VehicleService>();

            return services;
        }
    }
}
