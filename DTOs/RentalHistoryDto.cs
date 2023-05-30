using System.ComponentModel.DataAnnotations;

namespace lp_task.DTOs;

public class RentalHistoryDto
{
    [Required]
    public string CoverImage { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public DateTime RentalDate { get; set; }
    
    public DateTime? ReturnDate { get; set; }
    
    // public int? AvailableViews { get; set; }
    
    // public string? UniqueLink { get; set; }
}