using lp_task.DTOs;

namespace lp_task.Services;
public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetMoviesAsync(int page);
    Task<IEnumerable<MovieDto>> GetAnnouncementMoviesAsync(int page);
    Task<IEnumerable<MovieDto>> GetPremiereMoviesAsync(int page);
    Task<IEnumerable<MovieDto>> GetDiscountedMoviesAsync(int page);
    Task<IEnumerable<MovieDto>> GetMoviesAlphabeticallyAsync(int page);
    Task<IEnumerable<MovieDto>> GetFavoriteMoviesAsync(int page, string userId);
    Task<IEnumerable<MovieDto>> GetMoviesByTitleAsync(string title, int page);
    Task<IEnumerable<MovieDto>> GetMoviesByGenreAsync(string genre, int page);
    Task<IEnumerable<MovieDto>> GetMoviesByAgeAsync(int age, int page);
    Task<IEnumerable<MovieDto>> GetMoviesByDirectorAsync(
        string directorFirstName, 
        string directorLastName, 
        int page);
    Task<IEnumerable<MovieDto>> GetMoviesByReleaseDateAsync(
        DateTime? startDate, 
        DateTime? endDate, 
        int page);
    Task<bool> IsFavoriteMovieAsync(string movieId, string userId);
    Task AddFavoriteMovieAsync(string movieId, string userId);
    Task RemoveFavoriteMovieAsync(string movieId, string userId);
}