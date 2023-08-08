using AutoMapper;
using DesafioApiFilme.Data.Dtos.DtoSessao;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Profiles
{
    public class SessaoProfile: Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(sessaoDto => sessaoDto.FilmeId, opt => opt.MapFrom(sessao => sessao.Filme))
                .ForMember(sessaoDto => sessaoDto.CinemaId, opt => opt.MapFrom(sessao => sessao.Cinema));
            CreateMap<UpdateSessaoDto, Sessao>();
        }
    }
}