using lp_task.DTOs;
using lp_task.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lp_task.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalsController : ControllerBase
{
    private readonly IRentalService _rentalService;
    private readonly UserManager<IdentityUser> _userManager;

    public RentalsController(IRentalService rentalService, UserManager<IdentityUser> userManager)
    {
        _rentalService = rentalService;
        _userManager = userManager;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<RentalDto>> RentMovieAsync(RentalRequestDto rentalRequestDto)
    {
        if (User.Identity is { IsAuthenticated: false })
        {
            return BadRequest("User is not authenticated");
        }

        var userId = _userManager.GetUserId(User);

        if (userId != null && await _userManager.IsLockedOutAsync(await _userManager.FindByIdAsync(userId) ?? throw new InvalidOperationException()))
        {
            return BadRequest("User is locked out");
        }
        var rental = await _rentalService.RentMovieAsync(rentalRequestDto, userId);

        return Ok(rental);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<RentalDto>>> GetRentalsAsync()
    {
        if (User is not { Identity.IsAuthenticated: true })
        {
            return BadRequest("User is not authenticated");
        }

        var userId = _userManager.GetUserId(User);

        if (userId != null && await _userManager.IsLockedOutAsync(await _userManager.FindByIdAsync(userId)))
        {
            return BadRequest("User is locked out");
        }

        try
        {
            var rentals = await _rentalService.GetRentalsAsync(userId);
            return Ok(rentals);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving rentals.");
        }
    }
    
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<ActionResult<RentalDto>> GetRentalAsync(int id)
    {
        if (User is not { Identity.IsAuthenticated: true })
        {
            return BadRequest("User is not authenticated");
        }

        var userId = _userManager.GetUserId(User);

        if (userId != null && await _userManager.IsLockedOutAsync(await _userManager.FindByIdAsync(userId)))
        {
            return BadRequest("User is locked out");
        }

        try
        {
            var rental = await _rentalService.GetRentalAsync(id.ToString(), userId);
            return Ok(rental);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving rental.");
        }
    }
}
