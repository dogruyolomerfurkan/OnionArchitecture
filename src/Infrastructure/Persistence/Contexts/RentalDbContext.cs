using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Contexts;

public class RentalDbContext : DbContext
{
    public RentalDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<Brand>? Brands { get; set; }
    public DbSet<FuelType>? FuelTypes { get; set; }
    public DbSet<GearType>? GearTypes { get; set; }
    public DbSet<Model>? Models { get; set; }
    public DbSet<Serial>? Serials { get; set; }
    public DbSet<Vehicle>? Vehicles { get; set; }
    public DbSet<VehicleCategory>? VehicleCategories { get; set; }
}
