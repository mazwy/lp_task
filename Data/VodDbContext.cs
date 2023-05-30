using lp_task.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lp_task.Data;


public class VodDbContext : IdentityDbContext<VodUser>
{
    public VodDbContext(DbContextOptions<VodDbContext> options)
        : base(options)
    {
    }
    
    public VodDbContext()
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<FavoriteMovie> FavoriteMovies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<VodUser> VodUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<VodUser>()
            .HasMany(u => u.FavoriteMovies)
            .WithOne(fm => fm.User)
            .HasForeignKey(fm => fm.IdUser);

        builder.Entity<VodUser>()
            .HasMany(u => u.Rentals)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.IdUser);

        builder.Entity<VodUser>()
            .Property(u => u.FirstName)
            .IsRequired();

        builder.Entity<VodUser>()
            .Property(u => u.LastName)
            .IsRequired();

        builder.Entity<VodUser>()
            .Property(u => u.CreditCard)
            .IsRequired();

        builder.Entity<Country>()
            .HasMany(c => c.Movies)
            .WithOne(m => m.Country)
            .HasForeignKey(m => m.IdCountry);

        builder.Entity<Director>()
            .HasMany(d => d.Movies)
            .WithOne(m => m.Director)
            .HasForeignKey(m => m.IdDirector);

        builder.Entity<FavoriteMovie>()
            .HasKey(fm => new { fm.IdUser, fm.IdMovie });

        builder.Entity<FavoriteMovie>()
            .HasOne(fm => fm.User)
            .WithMany(u => u.FavoriteMovies)
            .HasForeignKey(fm => fm.IdUser)
            .HasPrincipalKey(u => u.Id);

        builder.Entity<FavoriteMovie>()
            .HasOne(fm => fm.Movie)
            .WithMany(m => m.FavoriteMovies)
            .HasForeignKey(fm => fm.IdMovie);

        builder.Entity<Genre>()
            .HasMany(g => g.Movies)
            .WithOne(m => m.Genre)
            .HasForeignKey(m => m.IdGenre);

        builder.Entity<Movie>()
            .HasMany(m => m.Rentals)
            .WithOne(r => r.Movie)
            .HasForeignKey(r => r.IdMovie);

        builder.Entity<Movie>()
            .HasOne(m => m.Director)
            .WithMany(d => d.Movies)
            .HasForeignKey(m => m.IdDirector);

        builder.Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.IdGenre);

        builder.Entity<Movie>()
            .HasOne(m => m.Country)
            .WithMany(c => c.Movies)
            .HasForeignKey(m => m.IdCountry);

        builder.Entity<Rental>()
            .HasOne(r => r.User)
            .WithMany(u => u.Rentals)
            .HasForeignKey(r => r.IdUser)
            .HasPrincipalKey(u => u.Id);

        builder.Entity<Rental>()
            .HasOne(r => r.Movie)
            .WithMany(m => m.Rentals)
            .HasForeignKey(r => r.IdMovie);
        
        // Seed countries
        builder.Entity<Country>().HasData(
            new Country { Id = "1", Name = "USA" },
            new Country { Id = "2", Name = "UK" },
            new Country { Id = "3", Name = "France" }
        );

        // Seed directors
        builder.Entity<Director>().HasData(
            new Director { Id = "1", FirstName = "Steven", LastName = "Spielberg" },
            new Director { Id = "2", FirstName = "Christopher", LastName = "Nolan" },
            new Director { Id = "3", FirstName = "Quentin", LastName = "Tarantino" }
        );

        // Seed genres
        builder.Entity<Genre>().HasData(
            new Genre { Id = "1", Name = "Action" },
            new Genre { Id = "2", Name = "Comedy" },
            new Genre { Id = "3", Name = "Drama" }
        );

        // Seed movies
        builder.Entity<Movie>().HasData(
            new Movie
            {
                Id = "1", 
                Title = "Jurassic Park", 
                CoverImage = "https://www.example.com/jurassic-park.jpg", 
                Duration = 127, 
                MinAge = 13, 
                Description = "A theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.", 
                ReleasePricePerDay = new decimal(4.99),
                ReleasePricePerView = new decimal(2.99),
                RentalPricePerDay = new decimal(1.99),
                RentalPricePerView = new decimal(0.99),
                ReleaseDate = new DateTime(1993, 6, 11), 
                IdDirector = "1", 
                IdGenre = "1", 
                IdCountry = "1"
            },
            new Movie
            {
                Id = "2", 
                Title = "The Dark Knight", 
                CoverImage = "https://www.example.com/the-dark-knight.jpg", 
                Duration = 152, 
                MinAge = 16, 
                Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", 
                ReleasePricePerDay = new decimal(5.99),
                ReleasePricePerView = new decimal(3.99),
                RentalPricePerDay = new decimal(2.99),
                RentalPricePerView = new decimal(1.99),
                ReleaseDate = new DateTime(2008, 7, 18), 
                IdDirector = "2",
                IdGenre = "1", 
                IdCountry = "1"
            },
            new Movie
            {
                Id = "3", 
                Title = "Pulp Fiction", 
                CoverImage = "https://www.example.com/pulp-fiction.jpg", 
                Duration = 154, 
                MinAge = 18, 
                Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                ReleasePricePerDay = new decimal(4.99),
                ReleasePricePerView = new decimal(2.99),
                RentalPricePerDay = new decimal(4.99),
                RentalPricePerView = new decimal(2.99),
                ReleaseDate = new DateTime(1994, 10, 14), 
                IdDirector = "3", 
                IdGenre = "3",
                IdCountry = "1"
            }
        );
        
        // Seed users
        builder.Entity<VodUser>().HasData(
            new VodUser
            {
                Id = "1", 
                UserName = "johndoe@example.com", 
                Email = "johndoe@example.com", 
                FirstName = "John", 
                LastName = "Doe", 
                CreditCard = "1234-5678-9012-3456"
            },
            new VodUser
            {
                Id = "2",
                UserName = "janedoe@example.com", 
                Email = "janedoe@example.com",
                FirstName = "Jane",
                LastName = "Doe",
                CreditCard = "5678-9012-3456-1234"
            }
        );

        // Seed favorite movies
        builder.Entity<FavoriteMovie>().HasData(
            new FavoriteMovie
            {
                IdUser = "1",
                IdMovie = "1"
            },
            new FavoriteMovie
            {
                IdUser = "1", 
                IdMovie = "2"
            },
            new FavoriteMovie
            {
                IdUser = "2", 
                IdMovie = "3"
            }
        );

        // Seed rentals
        builder.Entity<Rental>().HasData(
            new Rental
            {
                Id = "1", 
                IdUser = "1", 
                IdMovie = "1", 
                RentalDate = new DateTime(2021, 1, 1), 
                ReturnDate = new DateTime(2021, 1, 8)
            },
            new Rental
            {
                Id = "2", 
                IdUser = "1", 
                IdMovie = "2", 
                RentalDate = new DateTime(2021, 2, 1), 
                ReturnDate = new DateTime(2021, 2, 8)
            },
            new Rental
            {
                Id = "3", 
                IdUser = "2", 
                IdMovie = "3", 
                RentalDate = new DateTime(2021, 3, 1), 
                ReturnDate = new DateTime(2021, 3, 8)
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }
}
