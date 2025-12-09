using Microsoft.EntityFrameworkCore;
using MoviesToWatchApp.Backend.Models;

namespace MoviesToWatchApp.Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("movies");

            entity.HasKey(m => m.Id);

			entity.Property(m => m.Id)
            .ValueGeneratedOnAdd();

            entity.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(300);

            entity.Property(m => m.Priority)
            .HasConversion<int>()
            .HasDefaultValue(Movie.PriorityLevel.Medium);

        	entity.Property(m => m.Status)
            .HasConversion<int>()
            .HasDefaultValue(Movie.StatusType.ToWatch);

            entity.Property(m => m.CreatedAt)
                .HasDefaultValueSql("NOW()");
        });
    }
}
