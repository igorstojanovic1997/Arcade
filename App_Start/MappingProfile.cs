using Arcade.Dtos;
using Arcade.Models;
using AutoMapper;

namespace Arcade.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ReverseMap();
            Mapper.CreateMap<Game, GamesDto>().ReverseMap();
            Mapper.CreateMap<Genre, GenreDto>().ReverseMap();
        }
    }
}