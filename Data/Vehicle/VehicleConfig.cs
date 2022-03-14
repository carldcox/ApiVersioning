using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Domain;

namespace Data.Vehicle
{
    public class VehicleConfig : IEntityTypeConfiguration<Models.Domain.Vehicle>
    {
        public void Configure(EntityTypeBuilder<Models.Domain.Vehicle> builder)
        {
            builder.HasKey(v => v.Id);
            
            builder.Property(v => v.ModelName)
                .IsRequired();

            builder.HasData(
                new Models.Domain.Vehicle { Id = 1, BodyType = BodyType.Truck, ModelName = "Silverado" },
                new Models.Domain.Vehicle { Id = 2, BodyType = BodyType.Suv, ModelName = "Suburban" }
            );
        }
    }
}