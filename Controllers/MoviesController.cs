using lp_task.DTOs;
using lp_task.Models;
using lp_task.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lp_task.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;
    private readonly UserManager<VodUser> _userManager;

    public MovieController(
        IMovieService movieService, 
        UserManager<VodUser> userManager)
    {
        _movieService = movieService;
        _userManager = userManager;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetMoviesAsync(
        [FromQuery] Category? category = null,
        [FromQuery] string? title = null,
        [FromQuery] string? genre = null,
        [FromQuery] int viewerAge = 0,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] string? directorFirstName = null,
        [FromQuery] string? directorLastName = null,
        [FromQuery] int page = 0)
    {
        if (category != null)
        {
            switch (category)
            {
                case Category.Announcement:
                    return Ok(await _movieService.GetAnnouncementMoviesAsync(page));
                case Category.Premiere:
                    return Ok(await _movieService.GetPremiereMoviesAsync(page));
                case Category.Discount:
                    return Ok(await _movieService.GetDiscountedMoviesAsync(page));
                case Category.Favorite:
                {
                    if (User?.Identity?.IsAuthenticated != true)
                    {
                        return BadRequest("User is not authenticated");
                    }

                    var userId = _userManager.GetUserId(User);
                    if (userId == null)
                    {
                        return BadRequest("User ID is null");
                    }

                    return Ok(await _movieService.GetFavoriteMoviesAsync(page, userId));
                }
                case Category.Alphabetic:
                    return Ok(await _movieService.GetMoviesAlphabeticallyAsync(page));
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }

        if (title != null)
        {
            return Ok(await _movieService.GetMoviesByTitleAsync(title, page));
        }

        if (genre != null)
        {
            return Ok(await _movieService.GetMoviesByGenreAsync(genre, page));
        }

        if (viewerAge != 0)
        {
            return Ok(await _movieService.GetMoviesByAgeAsync(viewerAge, page));
        }

        if (startDate != null && endDate != null)
        {
            return Ok(await _movieService.GetMoviesByReleaseDateAsync(startDate, endDate, page));
        }

        if (directorFirstName != null && directorLastName != null)
        {
            return Ok(await _movieService.GetMoviesByDirectorAsync(directorFirstName, directorLastName, page));
        }

        return Ok(await _movieService.GetMoviesAsync(page));
    }
    
    [HttpPost("{movieId:int}/favorite")]
    [Authorize]
    public async Task<ActionResult> MarkMovieAsFavorite(string movieId)
    {
        if (string.IsNullOrEmpty(movieId))
        {
            return BadRequest("Movie ID is null or empty");
        }

        if (User?.Identity?.IsAuthenticated != true)
        {
            return BadRequest("User is not authenticated");
        }

        var userId = _userManager.GetUserId(User);

        if (await _movieService.IsFavoriteMovieAsync(movieId, userId))
        {
            await _movieService.RemoveFavoriteMovieAsync(movieId, userId);

            return Ok();
        }
        else
        {
            await _movieService.AddFavoriteMovieAsync(movieId, userId);

            return Ok();
        }
    }
}
