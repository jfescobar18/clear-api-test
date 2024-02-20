using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clear_api_test.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
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
            return _context.Movies.ToList();
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
}
