using MoviesToWatchApp.Backend.Models;

namespace MoviesToWatchApp.Backend.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (context.Movies.Any())
            return;

        context.Movies.AddRange(
            new Movie
            {
                Title = "The Matrix",
                Priority = Movie.PriorityLevel.High,
                Status = Movie.StatusType.ToWatch
            },
            new Movie
            {
                Title = "Interstellar",
                Priority = Movie.PriorityLevel.Medium,
                Status = Movie.StatusType.ToWatch
            }
        );

        await context.SaveChangesAsync();
    }
}