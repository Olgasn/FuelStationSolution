using FuelStation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelStation.Persistence.EntityTypeConfigurations
{
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(p => p.Id);
            //builder.HasOne("FuelStation.Domain.Tank")
            //    .WithMany()
            //    .HasForeignKey("TankId")
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired();
            //builder.HasOne("FuelStation.Domain.Fuel")
            //    .WithMany()
            //    .HasForeignKey("FuelId")
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired();



        }
    }
}
