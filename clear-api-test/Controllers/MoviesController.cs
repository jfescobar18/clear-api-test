using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MoviesDbContext _context;

    public MoviesController(MoviesDbContext context)
    {
        _context = context;
    }

    private bool MovieExists(int id)
    {
        return _context.Movies.Any(e => e.MovieId == id);
    }

    // GET: api/Movies
    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetMovies()
    {
        var movieActorsInfo = _context.MovieActors
        .Include(ma => ma.Movie)
        .Include(ma => ma.Actor)
        .ToList();

        var responseList = movieActorsInfo.Select(ma => new MovieActorResponseDto
        {
            title = ma.Movie?.Title,
            actors = ma.Actor?.Name
        }).ToList();

        return Ok(responseList);
    }

    // GET: api/Movies/1
    [HttpGet("{id}")]
    public ActionResult<Movie> GetMovie(int id)
    {
        var movie = _context.Movies.Find(id);

        if (movie == null)
        {
            return NotFound();
        }

        return movie;
    }

    // POST: api/Movies
    [HttpPost]
    public ActionResult<Movie> PostMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovie), new { id = movie.MovieId }, movie);
    }

    // PUT: api/Movies/1
    [HttpPut("{id}")]
    public IActionResult PutMovie(int id, Movie movie)
    {
        if (id != movie.MovieId)
        {
            return BadRequest();
        }

        _context.Entry(movie).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Movies/1
    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.Find(id);

        if (movie == null)
        {
            return NotFound();
        }

        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }
}
