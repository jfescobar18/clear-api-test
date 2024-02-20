using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ActorsController : ControllerBase
{
    private readonly MoviesDbContext _context;

    public ActorsController(MoviesDbContext context)
    {
        _context = context;
    }

    private bool ActorExists(int id)
    {
        return _context.Actors.Any(e => e.ActorId == id);
    }

    // GET: api/Actors
    [HttpGet]
    public ActionResult<IEnumerable<Actor>> GetActors()
    {
        return _context.Actors.ToList();
    }

    // GET: api/Actors/1
    [HttpGet("{id}")]
    public ActionResult<Actor> GetActor(int id)
    {
        var actor = _context.Actors.Find(id);

        if (actor == null)
        {
            return NotFound();
        }

        return actor;
    }

    // POST: api/Actors
    [HttpPost]
    public ActionResult<Actor> PostActor(Actor actor)
    {
        _context.Actors.Add(actor);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetActor), new { id = actor.ActorId }, actor);
    }

    // PUT: api/Actors/1
    [HttpPut("{id}")]
    public IActionResult PutActor(int id, Actor actor)
    {
        if (id != actor.ActorId)
        {
            return BadRequest();
        }

        _context.Entry(actor).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ActorExists(id))
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

    // DELETE: api/Actors/1
    [HttpDelete("{id}")]
    public IActionResult DeleteActor(int id)
    {
        var actor = _context.Actors.Find(id);

        if (actor == null)
        {
            return NotFound();
        }

        _context.Actors.Remove(actor);
        _context.SaveChanges();

        return NoContent();
    }
}
