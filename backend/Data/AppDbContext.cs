using Microsoft.EntityFrameworkCore;
using MoviesToWatchApp.Backend.Models;

namespace MoviesToWatchApp.backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("movies");

            entity.HasKey(m => m.Id);

            entity.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(300);

            entity.Property(m => m.Priority)
                .HasConversion<int>();

            entity.Property(m => m.CreatedAt)
                .HasDefaultValueSql("NOW()");

            entity.HasMany(m => m.MovieActors)
                .WithOne(ma => ma.Movie)
                .HasForeignKey(ma => ma.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Actor>(entity =>
        {
            entity.ToTable("actors");

            entity.HasKey(a => a.Id);

            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(a => a.TmdbId)
                .HasDefaultValue(null);
        });

        modelBuilder.Entity<MovieActor>(entity =>
        {
            entity.ToTable("movie_actors");

            entity.HasKey(ma => new { ma.MovieId, ma.ActorId });

            entity.HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId);

            entity.HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId);
        });
    }
}
