using AutoMapper;
using DesafioApiFilme.Data.Dtos.DtoFilme;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Profiles
{
    public class FilmeProfile: Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
            CreateMap<Filme, ReadFilmeDto>()
                .ForMember(filmeDto => filmeDto.Sessoes, opt => opt.MapFrom(filme => filme.Sessoes))
                .ForMember(filmeDto => filmeDto.GeneroId, opt => opt.MapFrom(filme => filme.Generos));
        }
    }
}