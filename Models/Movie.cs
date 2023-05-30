using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace lp_task.Models;

public class Movie
{
    [Key]
    public string Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string CoverImage { get; set; }

    [Required]
    public int Duration { get; set; }

    [Required]
    public int MinAge { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public decimal ReleasePricePerDay { get; set; }
    
    [Required]
    public decimal ReleasePricePerView { get; set; }

    [Required]
    public decimal RentalPricePerDay { get; set; }

    [Required]
    public decimal RentalPricePerView { get; set; }

    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public string IdDirector { get; set; }

    [Required]
    public string IdGenre { get; set; }

    [Required]
    public string IdCountry { get; set; }

    
    public virtual Director Director { get; set; }

    public virtual Genre Genre { get; set; }

    public virtual Country Country { get; set; }

    public virtual ICollection<FavoriteMovie>? FavoriteMovies { get; set; }

    public virtual ICollection<Rental>? Rentals { get; set; }
}