using System.ComponentModel.DataAnnotations;
using lp_task.Models;

namespace lp_task.DTOs;

public class MovieDto
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Genre { get; set; }

    [Required]
    public string CoverImage { get; set; }
    
    [Required]
    public bool IsFavorite { get; set; }
}