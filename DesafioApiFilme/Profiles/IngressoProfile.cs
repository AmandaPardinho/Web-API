using AutoMapper;
using DesafioApiFilme.Data.Dtos.DtoIngresso;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Profiles
{
    public class IngressoProfile: Profile
    {
        public IngressoProfile()
        {
            CreateMap<CreateIngressoDto, Ingresso>();
            CreateMap<Ingresso, ReadIngressoDto>()
                .ForMember(ingressoDto => ingressoDto.SessaoId, opt => opt.MapFrom(ingresso => ingresso.Sessao));
            CreateMap<UpdateIngressoDto, Ingresso>();
        }
    }
}
