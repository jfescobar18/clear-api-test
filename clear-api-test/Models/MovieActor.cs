using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DB;

public class MovieActor
{
    [Key]
    public int MovieActorId { get; set; }

    public int MovieId { get; set; }
    public int ActorId { get; set; }

    [ForeignKey("MovieId")]
    public virtual Movie? Movie { get; set; }

    [ForeignKey("ActorId")]
    public virtual  Actor? Actor { get; set; }
}
