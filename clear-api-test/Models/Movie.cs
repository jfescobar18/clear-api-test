using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
