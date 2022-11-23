using Microsoft.EntityFrameworkCore;

namespace RentaCar;

public sealed class AppContext : DbContext
{
    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Rental> Rentals { get; set; } = null!;

    public AppContext()
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Database=Cars;Username=postgres;Password=root");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().ToTable("Accounts");
        modelBuilder.Entity<Car>().ToTable("Cars");
        modelBuilder.Entity<Rental>().ToTable("Rental_Cars");
    }
}