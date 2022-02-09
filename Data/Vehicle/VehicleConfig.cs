using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Vehicle
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.Id);
            
            builder.Property(v => v.ModelName)
                .IsRequired();

            builder.HasData(
                new Vehicle { Id = 1, BodyType = BodyType.Truck, ModelName = "Silverado" },
                new Vehicle { Id = 2, BodyType = BodyType.Suv, ModelName = "Suburban" }
            );
        }
    }
}