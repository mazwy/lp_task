using System.ComponentModel.DataAnnotations;

namespace lp_task.DTOs;

public class UserDto
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.CreditCard)]
    public string CreditCard { get; set; }
}