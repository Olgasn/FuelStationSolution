using FuelStation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelStation.Persistence.EntityTypeConfigurations
{
    public class TankConfiguration : IEntityTypeConfiguration<Tank>
    {
        public void Configure(EntityTypeBuilder<Tank> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TankType).IsRequired().HasMaxLength(35);

        }
    }
}
