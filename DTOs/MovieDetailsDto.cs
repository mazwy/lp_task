using System.ComponentModel.DataAnnotations;

namespace lp_task.DTOs;

public class MovieDetailsDto : MovieDto
{
    [Required]
    public string Director { get; set; }
    
    [Required]
    public int Duration { get; set; }
    
    [Required]
    public string Country { get; set; }
    
    [Required]
    public int MinAge { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public decimal RentalPricePerDay { get; set; }
    
    [Required]
    public decimal RentalPricePerView { get; set; }
}