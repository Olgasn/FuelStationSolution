using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using FuelStation.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Persistence
{
    public class FuelStationDbContext : DbContext, IFuelStationDbContext
    {
        public DbSet<Fuel> Fuels { get; set; } = null!;
        public DbSet<Tank> Tanks { get; set; } = null!;
        public DbSet<Operation> Operations { get; set; } = null!;
        public FuelStationDbContext(DbContextOptions<FuelStationDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FuelConfiguration());
            builder.ApplyConfiguration(new TankConfiguration());
            builder.ApplyConfiguration(new OperationConfiguration());


            base.OnModelCreating(builder);
        }
    }
}