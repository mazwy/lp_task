using lp_task.DTOs;
using lp_task.Models;

namespace lp_task.Services;

public interface IRentalService
{
    Task<RentalDto> RentMovieAsync(RentalRequestDto rentalRequestDto, string userId);
    Task<RentalDto> GetRentalsAsync(string userId);
    Task<RentalDto> GetRentalAsync(string rentalId, string userId);
}
