using Microsoft.EntityFrameworkCore;

namespace CarRental.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CarBody>().HasKey(cb => cb.TruckId);
            builder.Entity<CarBody>().Property(cb => cb.TruckId).ValueGeneratedNever();
            builder.Entity<CarBody>().HasIndex(cb => cb.CarBodyNum).IsUnique();
            builder.Entity<CarBody>().HasOne(cb => cb.Truck).WithOne(t => t.CarBody)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Engine>().HasKey(e => e.TruckId);
            builder.Entity<Engine>().Property(e => e.TruckId).ValueGeneratedNever();
            builder.Entity<Engine>().HasIndex(e => e.VIN).IsUnique();
            builder.Entity<Engine>().HasOne(e => e.Truck).WithOne(t => t.Engine)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Engine>().HasOne(e => e.EngineSpecifications).WithMany(es => es.Engines)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CarBody> CarBodies { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }
        public virtual DbSet<EngineSpecification> EngineSpecifications { get; set; }
        public virtual DbSet<FuelInjection> FuelInjections { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Trailer> Trailers { get; set; }
        public virtual DbSet<Truck> Trucks { get; set; }
    }
}
