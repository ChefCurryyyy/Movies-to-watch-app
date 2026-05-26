using Microsoft.AspNetCore.Mvc;
using MoviesToWatchApp.Backend.Controllers;
using MoviesToWatchApp.Backend.Models;
using Xunit;

namespace Backend.Tests;

public class MoviesControllerTests : IClassFixture<TestDatabaseFixture>
{
    private readonly TestDatabaseFixture _fixture;

    public MoviesControllerTests(TestDatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetMovies_ReturnsOrderedMovies_WhenDatabaseHasData()
    {
        // Arrange
        using var context = _fixture.CreateContext();
        
        var movie1 = new Movie { Title = "Inception", CreatedAt = DateTime.UtcNow.AddMinutes(-10) };
        var movie2 = new Movie { Title = "The Matrix", CreatedAt = DateTime.UtcNow }; // Newer
        
        context.Movies.AddRange(movie1, movie2);
        await context.SaveChangesAsync();

        var controller = new MoviesController(context);

        // Act
        var result = await controller.GetMovies();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var movies = Assert.IsAssignableFrom<IEnumerable<Movie>>(actionResult.Value).ToList();

        Assert.Equal(2, movies.Count);
        Assert.Equal("The Matrix", movies[0].Title); // Should be first due to OrderByDescending
    }

    [Fact]
    public void MovieModel_ShouldHaveDefaultValues()
    {
        // Act
        var movie = new Movie { Title = "Test Movie" };

        // Assert
        Assert.Equal(Movie.PriorityLevel.Medium, movie.Priority);
        Assert.Equal(Movie.StatusType.ToWatch, movie.Status);
    }
}