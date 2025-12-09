using System;
using System.Collections.Generic;

namespace MoviesToWatchApp.Backend.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Priority Priority { get; set; } = Priority.Medium;
    public Status Status { get; set; } = Status.ToWatch;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
        
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