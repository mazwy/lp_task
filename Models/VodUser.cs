using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace lp_task.Models;

[Index(nameof(Email), IsUnique = true)]
public class VodUser : IdentityUser
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }

    [Required]
    public string CreditCard { get; set; }

    public virtual IEnumerable<FavoriteMovie>? FavoriteMovies { get; set; }
    public virtual ICollection<Rental>? Rentals { get; set; }
}