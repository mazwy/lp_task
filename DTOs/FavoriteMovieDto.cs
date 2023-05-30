using System.ComponentModel.DataAnnotations;
using lp_task.Models;

namespace lp_task.DTOs;

public class FavoriteMovieDto
{
    [Required]
    public string IdUser { get; set; }
    
    [Required]
    public string IdMovie { get; set; }
}