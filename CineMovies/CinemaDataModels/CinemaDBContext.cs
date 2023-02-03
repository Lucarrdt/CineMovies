using Microsoft.EntityFrameworkCore;

namespace CineMovies.CinemaData;

public class CinemaDBContext : DbContext
{
    public CinemaDBContext(DbContextOptions<CinemaDBContext> options) : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CinemaDb;Trusted_Connection=True;");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasMany(m => m.Reservations).WithOne(r => r.Movie);
        modelBuilder.Entity<User>().HasMany(u => u.Reservations).WithOne(r => r.User);
    }
}