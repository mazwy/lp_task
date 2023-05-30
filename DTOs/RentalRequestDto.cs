using System.ComponentModel.DataAnnotations;
using lp_task.Models;

namespace lp_task.DTOs;

public class RentalRequestDto
{
    public string IdRental { get; set; }
    
    [Required]
    public string IdMovie { get; set; }
    
    [Required]
    public string IdUser { get; set; }
    
    [Required]
    public DateTime RentalDate { get; set; }
    
    public DateTime? ReturnDate { get; set; }
    
    [Required]
    public RentalType RentalType { get; set; }
    
    public int? RentalDays { get; set; }
    public int? RentalViews { get; set; }
    
    [Required]
    public decimal RentalPrice { get; set; }   
}