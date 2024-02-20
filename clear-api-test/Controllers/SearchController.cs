using System.Collections.Generic;
using System.Linq;
using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly MoviesDbContext _context;

    public SearchController(MoviesDbContext context)
    {
        _context = context;
    }

    // GET: api/Search/ByTitle?title=YourTitle
    [HttpGet("ByTitle")]
    public ActionResult<IEnumerable<Movie>> GetMoviesByTitle([FromQuery] string title)
    {
        var movies = _context.Movies
            .Where(m => m.Title.Contains(title))
            .ToList();

        return movies;
    }

    // GET: api/Search/ByActor?actorIds=1,2,3
    [HttpGet("ByActorId")]
    public ActionResult<IEnumerable<Movie>> GetMoviesByActor([FromQuery] List<int> actorIds)
    {
        var movies = _context.MovieActors
            .Where(ma => actorIds.Contains(ma.ActorId))
            .Select(ma => ma.Movie)
            .Distinct()
            .ToList();

        return movies;
    }

    // GET: api/Search/ByActor?actorNames=Actor1,Actor2,Actor3
    [HttpGet("ByActorName")]
    public ActionResult<IEnumerable<Movie>> GetMoviesByActor([FromQuery] List<string> actorNames)
    {
        var movies = _context.MovieActors
            .Where(ma => actorNames.Contains(ma.Actor.Name))
            .Select(ma => ma.Movie)
            .Distinct()
            .ToList();

        return movies;
    }
}
