using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lp_task.Models;

public class Rental
{
    [Key]
    public string Id { get; set; }

    [Required]
    public string IdUser { get; set; }

    [Required]
    public string IdMovie { get; set; }

    [ForeignKey("IdUser")]
    public virtual VodUser User { get; set; }

    [ForeignKey("IdMovie")]
    public virtual Movie Movie { get; set; }

    [Required]
    public DateTime RentalDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    [Required]
    public bool Returned { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public RentalType RentalType { get; set; }
    
    [Required]
    public int RentalValue { get; set; }
    
    public int RentalValueUsed { get; set; }
}