using System.ComponentModel.DataAnnotations;

namespace lp_task.DTOs;

public class CountryDto
{
    public string Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}