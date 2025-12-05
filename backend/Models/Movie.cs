using System;
using System.Collections.Generic;

namespace MoviesToWatchApp.Backend.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; } = Priority.Medium;
    public Status Status { get; set; } = Status.ToWatch;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime SeenAt { get; set; }
    public float Rating { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string? PosterUrl { get; set; }
    public string? BackdropUrl { get; set; }
    
    public ICollection<MovieActor> Cast { get; set; } = new List<MovieActor>();
    
    public enum Priority
    {
        High = 1,
        Medium = 2,
        Low = 3
    }

    public enum Status
    {
        ToWatch = 1,
        Watching = 2,
        Seen = 3
    }
}