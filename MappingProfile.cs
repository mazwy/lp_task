using AutoMapper;
using lp_task.DTOs;
using lp_task.Models;

namespace lp_task;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<Director, DirectorDto>();
        CreateMap<FavoriteMovie, FavoriteMovieDto>();
        CreateMap<Genre, GenreDto>();
        
        CreateMap<Movie, MovieDto>()
            .ForMember(dest => dest.Genre, 
                opt => opt.MapFrom(
                    src => src.IdGenre))
            .ForMember(dest => dest.IsFavorite, 
                opt => opt.Ignore());

        CreateMap<Movie, MovieDetailsDto>()
            .IncludeBase<Movie, MovieDto>()
            .ForMember(dest => dest.Genre, 
                opt => opt.MapFrom(
                    src => src.Genre.Name))
            .ForMember(dest => dest.Director, 
                opt => opt.MapFrom(
                    src => $"{src.Director.FirstName} {src.Director.LastName}"))
            .ForMember(dest => dest.Country, 
                opt => opt.MapFrom(
                    src => src.Country.Name));
        
        CreateMap<Rental, RentalDto>();
        CreateMap<Rental, RentalHistoryDto>();
        CreateMap<RentalRequestDto, Rental>();
        CreateMap<UserDto, VodUser>();
    }
}