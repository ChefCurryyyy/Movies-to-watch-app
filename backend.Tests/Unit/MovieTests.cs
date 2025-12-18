using System;
using MoviesToWatchApp.Backend.Models;
using Xunit;

namespace Backend.Tests.Unit;

public class MovieTests
{
    [Fact]
    public void NewMovie_ShouldHaveDefaultPriority_Medium()
    {
        // Act
        var movie = new Movie();

        // Assert
        Assert.Equal(Movie.PriorityLevel.Medium, movie.Priority);
    }

    [Fact]
    public void NewMovie_ShouldHaveDefaultStatus_ToWatch()
    {
        // Act
        var movie = new Movie();

        // Assert
        Assert.Equal(Movie.StatusType.ToWatch, movie.Status);
    }

    [Fact]
    public void CanSetPriorityExplicitly()
    {
        // Arrange
        var movie = new Movie();

        // Act
        movie.Priority = Movie.PriorityLevel.High;

        // Assert
        Assert.Equal(Movie.PriorityLevel.High, movie.Priority);
    }

    [Fact]
    public void CanSetStatusExplicitly()
    {
        // Arrange
        var movie = new Movie();

        // Act
        movie.Status = Movie.StatusType.Seen;

        // Assert
        Assert.Equal(Movie.StatusType.Seen, movie.Status);
    }

    [Fact]
    public void CanAssignTitle()
    {
        // Arrange
        var title = "Inception";

        // Act
        var movie = new Movie
        {
            Title = title
        };

        // Assert
        Assert.Equal(title, movie.Title);
    }

    [Fact]
    public void CreatedAt_CanBeSet()
    {
        // Arrange
        var now = DateTime.UtcNow;

        // Act
        var movie = new Movie
        {
            CreatedAt = now
        };

        // Assert
        Assert.Equal(now, movie.CreatedAt);
    }
}