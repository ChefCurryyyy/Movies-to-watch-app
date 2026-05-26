using System;
using System.Collections.Generic;

namespace MoviesToWatchApp.Backend.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public PriorityLevel Priority { get; set; } = Movie.PriorityLevel.Medium;
    public StatusType Status { get; set; } = Movie.StatusType.ToWatch;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public enum PriorityLevel
    {
        High = 1,
        Medium = 2,
        Low = 3
    }

    public enum StatusType
    {
        ToWatch = 1,
        Watching = 2,
        Seen = 3
    }
}