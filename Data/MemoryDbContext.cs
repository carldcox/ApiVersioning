using Data.Vehicle;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MemoryDbContext : DbContext
    {
        public MemoryDbContext(DbContextOptions<MemoryDbContext> options)
            : base(options)
        { }
        
        public virtual DbSet<Models.Domain.Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) return;

            modelBuilder.ApplyConfiguration(new VehicleConfig());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}