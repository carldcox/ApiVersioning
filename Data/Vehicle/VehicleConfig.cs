using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Vehicle
{
    public class VehicleConfig : IEntityTypeConfiguration<Models.Domain.Vehicle>
    {
        public void Configure(EntityTypeBuilder<Models.Domain.Vehicle> builder)
        {
            builder.HasKey(v => v.Id);
            
            builder.Property(v => v.ModelName)
                .IsRequired();
        }
    }
}