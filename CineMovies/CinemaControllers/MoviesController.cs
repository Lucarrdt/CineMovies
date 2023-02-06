using CineMovies.CinemaData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineMovies.CinemaControllers;

public class MoviesController : ControllerBase
{
    private readonly CinemaDBContext _context;
    public MoviesController(CinemaDBContext context) => _context = context;
    public bool MovieExists(int id) => _context.Movies.Any(e => e.Id == id);
    
    /// <summary>
    /// GetMovies() returns a list of all movies in the database. & GetMovie() returns a movie with the given id.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    {
        return await _context.Movies.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        
        if (movie == null)
        {
            return NotFound();
        }
        
        return movie;
    }
}