using System.ComponentModel.DataAnnotations;

namespace lp_task.Models;

public class Director
{
    [Key]
    public string Id { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    public virtual ICollection<Movie> Movies { get; set; }
}