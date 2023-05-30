using System.ComponentModel.DataAnnotations;

namespace lp_task.Models;

public class Genre
{
    [Key]
    public string Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public virtual ICollection<Movie> Movies { get; set; }
}