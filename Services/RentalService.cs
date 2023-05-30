using AutoMapper;
using lp_task.Data;
using lp_task.DTOs;
using lp_task.Models;
using Microsoft.EntityFrameworkCore;

namespace lp_task.Services;

public class RentalService : IRentalService
{
    private readonly VodDbContext _context;
    private readonly IMapper _mapper;

    public RentalService(VodDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RentalDto> RentMovieAsync(RentalRequestDto rentalRequestDto, string userId)
    {
        var movie = await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == rentalRequestDto.IdMovie);

        if (movie == null)
        {
            throw new Exception("Movie not found");
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == rentalRequestDto.IdUser.ToString());

        if (user == null)
        {
            throw new Exception("User not found");
        }

        var rental = await _context.Rentals
            .FirstOrDefaultAsync(
                r => r.IdMovie == rentalRequestDto.IdMovie 
                && r.IdUser == rentalRequestDto.IdUser);

        if (rental != null)
        {
            throw new Exception("Movie already rented");
        }

        var rentals = await _context.Rentals
            .Where(r => r.IdUser == rentalRequestDto.IdUser)
            .ToListAsync();

        if (rentals.Count >= 10)
        {
            throw new Exception("User has too many rentals");
        }

        var rentalsCount = await _context.Rentals
            .Where(r => r.IdMovie == rentalRequestDto.IdMovie)
            .ToListAsync();

        if (rentalsCount.Count >= 100)
        {
            throw new Exception("Movie has too many rentals");
        }

        rentalRequestDto.RentalPrice = rentalRequestDto.RentalType switch
        {
            RentalType.PerDay when rentalRequestDto.RentalDays == null => throw new Exception(
                "Rental days not specified"),
            RentalType.PerDay => movie.RentalPricePerDay * rentalRequestDto.RentalDays.Value,
            RentalType.PerView when rentalRequestDto.RentalViews == null => throw new Exception(
                "Rental views not specified"),
            RentalType.PerView => movie.RentalPricePerView * rentalRequestDto.RentalViews.Value,
            _ => throw new Exception("Rental type not specified")
        };

        var rent = _mapper.Map<Rental>(rentalRequestDto);
        _context.Rentals.Add(rent);
        await _context.SaveChangesAsync();

        var rentalDto = _mapper.Map<RentalDto>(rent);

        return rentalDto;
    }

    public async Task<RentalDto> GetRentalsAsync(string userId)
    {
        var rentals = await _context.Rentals
            .Where(r => r.IdUser == userId)
            .ToListAsync();

        var rentalDto = _mapper.Map<RentalDto>(rentals);

        return rentalDto;
    }
    
    public async Task<RentalDto> GetRentalAsync(string id, string userId)
    {
        var rental = await _context.Rentals
            .FirstOrDefaultAsync(r => r.Id == id && r.IdUser == userId);

        if (rental == null)
        {
            throw new Exception("Rental not found");
        }
        
        switch (rental.RentalType)
        {
            case RentalType.PerDay when rental.RentalValue == null:
                throw new Exception("Rental days not specified");
            case RentalType.PerDay when rental.RentalValue < 0:
                throw new Exception("Rental days cannot be negative");
            case RentalType.PerDay:
            {
                if (rental.RentalValue > 0)
                {
                    if (rental.RentalValue < (DateTime.Now - rental.RentalDate).Days)
                    {
                        throw new Exception("Rental expired");
                    }
                }

                break;
            }
            case RentalType.PerView when rental.RentalValue == null:
                throw new Exception("Rental views not specified");
            case RentalType.PerView when rental.RentalValue < 0:
                throw new Exception("Rental views cannot be negative");
            case RentalType.PerView:
            {
                if (rental.RentalValue > 0)
                {
                    if (rental.RentalValue == rental.RentalValueUsed)
                    {
                        throw new Exception("Rental expired");
                    }
                }
                break;
            }
            default:
                throw new Exception("Rental type not specified");
        }
        
        var rentalDto = _mapper.Map<RentalDto>(rental);
        
        return rentalDto;
    }
}
