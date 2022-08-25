using FuelStation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelStation.Persistence.EntityTypeConfigurations
{
    public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FuelType).IsRequired().HasMaxLength(35);
        }
    }
}
