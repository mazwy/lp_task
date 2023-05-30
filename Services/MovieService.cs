using lp_task.Data;
using lp_task.DTOs;
using lp_task.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace lp_task.Services;
public class MovieService : IMovieService
{
    private readonly VodDbContext _context;
    private readonly IMapper _mapper;

    public MovieService(VodDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDto>> GetMoviesAsync(int page)
    {
        var movies = await _context.Movies
            .Skip(page * 10)
            .Take(10)
            .ToListAsync();

        var moviesDto = _mapper.Map<List<MovieDto>>(movies);

        return moviesDto;
    }

    public async Task<IEnumerable<MovieDto>> GetAnnouncementMoviesAsync(int page)
    {
        var movies = await _context.Movies
            .Where(m => m.ReleaseDate >= DateTime.Now)
            .Skip(page * 10)
            .Take(10)
            .ToListAsync();

        var moviesDto = _mapper.Map<List<MovieDto>>(movies);

        return moviesDto;
    }

    public async Task<IEnumerable<MovieDto>> GetPremiereMoviesAsync(int page)
    {
        var movies = await _context.Movies
            .Where(m => m.ReleaseDate <= DateTime.Now)
            .Skip(page * 10)
            .Take(10)
            .ToListAsync();

        var moviesDto = _mapper.Map<List<MovieDto>>(movies);

        return moviesDto;
    }

    public async Task<IEnumerable<MovieDto>> GetDiscountedMoviesAsync(int page)
    {
        var movies = await _context.Movies
            .Where(m => m.RentalPricePerDay < m.ReleasePricePerDay ||
                        m.RentalPricePerView < m.ReleasePricePerView)
            .Skip(page * 10)
            .Take(10)
            .ToListAsync();

        var moviesDto = _mapper.Map<List<MovieDto>>(movies);

        return moviesDto;
    }

    public async Task<IEnumerable<MovieDto>> GetMoviesAlphabeticallyAsync(int page)
    {
        var movies = await _context.Movies
            .OrderBy(m => m.Title)
            .Skip(page * 10)
            .Take(10)
            .ToListAsync();

        var moviesDto = _mapper.Map<List<MovieDto>>(movies);

        return moviesDto;
    }

    public async Task<IEnumerable<MovieDto>> GetFavoriteMoviesAsync(int page, string userId)
    {
        var movies = await _context.Movies
            .Where(m => m.FavoriteMovies.Any(fm => fm.IdUser == userId))
            .Skip(page * 10)
            .Take(10)
            .ToListAsync();

        var moviesDto = _mapper.Map<List<MovieDto>>(movies);

        return moviesDto;
    }

    public async Task<IEnumerable<MovieDto>> GetMoviesByTitleAsync(string title, int page)
    {
        var movies = await _context.Movies
            .Where(m => m.Title.Contains(title))
            .Skip(page * 10)
            .Take(10)
            .ToListAsync();

        var moviesDto = _mapper.Map<List<MovieDto>>(movies);

        return moviesDto;
    }

    public async Task<IEnumerable<MovieDto>> GetMoviesByGenreAsync(string genre, int page)
    {
        var movies = await _context.Movies
            .Where(m => m.Genre.Name.Contains(genre))
            .Skip(page * 10)
            .Take(10)
            .ToListAsync();

        var moviesDto = _mapper.Map<List<MovieDto>>(movies);

        return moviesDto;
    }

    public async Task<IEnumerable<MovieDto>> GetMoviesByAgeAsync(int age, int page)
    {
        var movies = await _context.Movies
            .Where(m => m.MinAge <= age)
            .Skip(page * 10)
            .Take(10)
            .ToListAsync();

        var moviesDto = _mapper.Map<List<MovieDto>>(movies);

        return moviesDto;
    }

    public async Task<IEnumerable<MovieDto>> GetMoviesByDirectorAsync(string directorFirstName, string directorLastName, int page)
    {
        var movies = await _context.Movies
            .Where(m => m.Director.FirstName.Contains(directorFirstName) && m.Director.LastName.Contains(directorLastName))
            .Skip(page * 10)
            .Take(10)
            .ToListAsync();

        var moviesDto = _mapper.Map<List<MovieDto>>(movies);

        return moviesDto;
    }

    public async Task<IEnumerable<MovieDto>> GetMoviesByReleaseDateAsync(
        DateTime? startDate, 
        DateTime? endDate, 
        int page)
    {
        if (startDate == null || endDate == null)
        {
            throw new ArgumentException("Both start date and end date must be provided");
        }

        var movies = await _context.Movies
            .Where(m => m.ReleaseDate >= startDate && m.ReleaseDate <= endDate)
            .Skip(page * 10)
            .Take(10)
            .ToListAsync();

        var moviesDto = _mapper.Map<List<MovieDto>>(movies);

        return moviesDto;
    }

    public async Task<bool> IsFavoriteMovieAsync(string movieId, string userId)
    {
        var favoriteMovie = await _context.FavoriteMovies
            .FirstOrDefaultAsync(fm => fm.IdMovie == movieId && fm.IdUser == userId);

        return favoriteMovie != null;
    }

    public async Task AddFavoriteMovieAsync(string movieId, string userId)
    {
        var favoriteMovie = new FavoriteMovie
        {
            IdMovie = movieId,
            IdUser = userId
        };

        await _context.FavoriteMovies.AddAsync(favoriteMovie);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveFavoriteMovieAsync(string movieId, string userId)
    {
        var favoriteMovie = await _context.FavoriteMovies
            .FirstOrDefaultAsync(fm => fm.IdMovie == movieId && fm.IdUser == userId);

        if (favoriteMovie != null)
        {
            _context.FavoriteMovies.Remove(favoriteMovie);
            await _context.SaveChangesAsync();
        }
    }
}