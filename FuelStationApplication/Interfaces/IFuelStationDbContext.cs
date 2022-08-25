using FuelStation.Domain;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Application.Interfaces
{
    public interface IFuelStationDbContext
    {
        DbSet<Fuel> Fuels { set; get; }
        DbSet<Tank> Tanks { set; get; }
        DbSet<Operation> Operations { set; get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
