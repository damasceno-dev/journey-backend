using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
namespace Journey.Infrastructure;

public class JourneyDbContext: DbContext
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Activity> Activities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var isLocalDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_LOCAL_CONTAINER") == "true";
        var dbHost = isLocalDocker ? "host.docker.internal" : "localhost";
        var connectionString =
            $"Host={dbHost};Database=journey;Username=postgres;Password=reallyStrongPwd123";
        Console.WriteLine(connectionString);
        optionsBuilder.UseNpgsql(connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Activity>().Property(p => p.Date).HasConversion(
            v => v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)); 
        modelBuilder.Entity<Trip>().Property(p => p.StartDate).HasConversion(
            v => v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));        
        modelBuilder.Entity<Trip>().Property(p => p.EndDate).HasConversion(
            v => v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
    }
}