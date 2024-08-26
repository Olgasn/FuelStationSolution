using FuelStation.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FuelStation.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            string connectionString = configuration["DbConnection"] ?? "";
            services.AddDbContext<FuelStationDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IFuelStationDbContext>(provider =>
                provider.GetService<FuelStationDbContext>());

            return services;
        }
    }
}
