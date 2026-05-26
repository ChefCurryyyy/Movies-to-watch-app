using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesToWatchApp.Backend.Data;
using MoviesToWatchApp.Backend.Models;

namespace MoviesToWatchApp.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies([FromQuery] string? status)
    {
        var query = _context.Movies.AsQueryable();

        if (!string.IsNullOrEmpty(status) && Enum.TryParse<Movie.StatusType>(status, ignoreCase: true, out var parsedStatus))
            query = query.Where(m => m.Status == parsedStatus);

        var movies = await query
            .OrderByDescending(m => m.CreatedAt)
            .ToListAsync();

        return Ok(movies);
    }
} 
