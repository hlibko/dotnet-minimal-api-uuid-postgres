using dotnet_minimal_api_uuid_postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_minimal_api_uuid_postgres.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(b =>
        {
            b.HasKey(u => u.Id);
            b.Property(u => u.Id)
             .HasDefaultValueSql("gen_random_uuid()")
             .ValueGeneratedOnAdd();
            b.Property(u => u.Username).IsRequired();
        });
    }
}
