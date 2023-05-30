using lp_task.Data;
using lp_task.DTOs;
using lp_task.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lp_task.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<VodUser> _userManager;
    private readonly VodDbContext _context;
    
    public UsersController(UserManager<VodUser> userManager, VodDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register([FromBody] UserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByEmailAsync(userDto.Email);

        if (user != null)
        {
            return BadRequest("User already exists");
        }

        var newUser = new VodUser
        {
            Email = userDto.Email,
            UserName = userDto.Email,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            CreditCard = userDto.CreditCard
        };

        var result = await _userManager.CreateAsync(
            newUser,
            userDto.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return BadRequest(ModelState);
        }

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        userDto.Password = null!;

        return Created("", userDto);
    }
}
