using AutoMapper;
using DesafioApiFilme.Data.Dtos;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Profiles
{
    public class CinemaProfile: Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(cinemaDto => cinemaDto.Endereco, opt => opt.MapFrom(cinema => cinema.Endereco))
                .ForMember(cinemaDto => cinemaDto.Sessoes, opt => opt.MapFrom(cinema => cinema.Sessoes));
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
