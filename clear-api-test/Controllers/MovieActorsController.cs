using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MovieActorsController : ControllerBase
{
    private readonly MoviesDbContext _context;

    public MovieActorsController(MoviesDbContext context)
    {
        _context = context;
    }

    private bool MovieActorExists(int id)
    {
        return _context.MovieActors.Any(e => e.MovieActorId == id);
    }

    // GET: api/MovieActors
    [HttpGet]
    public ActionResult<IEnumerable<MovieActor>> GetMovieActors()
    {
        return _context.MovieActors.ToList();
    }

    // GET: api/MovieActors/1
    [HttpGet("{id}")]
    public ActionResult<MovieActor> GetMovieActor(int id)
    {
        var movieActor = _context.MovieActors.Find(id);

        if (movieActor == null)
        {
            return NotFound();
        }

        return movieActor;
    }

    // POST: api/MovieActors
    [HttpPost]
    public ActionResult<MovieActor> PostMovieActor(MovieActor movieActor)
    {
        _context.MovieActors.Add(movieActor);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovieActor), new { id = movieActor.MovieActorId }, movieActor);
    }

    // PUT: api/MovieActors/1
    [HttpPut("{id}")]
    public IActionResult PutMovieActor(int id, MovieActor movieActor)
    {
        if (id != movieActor.MovieActorId)
        {
            return BadRequest();
        }

        _context.Entry(movieActor).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieActorExists(id))
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

    // DELETE: api/MovieActors/1
    [HttpDelete("{id}")]
    public IActionResult DeleteMovieActor(int id)
    {
        var movieActor = _context.MovieActors.Find(id);

        if (movieActor == null)
        {
            return NotFound();
        }

        _context.MovieActors.Remove(movieActor);
        _context.SaveChanges();

        return NoContent();
    }
}
