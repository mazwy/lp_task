using System.ComponentModel.DataAnnotations;
using lp_task.Models;

namespace lp_task.DTOs;

public class DirectorDto
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }

    public virtual IEnumerable<Movie> Movies { get; set; }
}