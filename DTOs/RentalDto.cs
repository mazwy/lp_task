using System;
using System.ComponentModel.DataAnnotations;
using lp_task.Models;

namespace lp_task.DTOs;

public class RentalDto
{
    public string Id { get; set; }
    
    [Required]
    public string MovieId { get; set; }
    
    [Required]
    public string MovieTitle { get; set; }
    
    [Required]
    public DateTime RentalDate { get; set; }
    
    
    public RentalType RentalType { get; set; }
    public int RentalValue { get; set; }
}