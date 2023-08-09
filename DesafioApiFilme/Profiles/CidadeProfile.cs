using AutoMapper;
using DesafioApiFilme.Data.Dtos.DtoCidade;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Profiles
{
    public class CidadeProfile: Profile
    {
        public CidadeProfile()
        {
            CreateMap<CreateCidadeDto, Cidade>();
            CreateMap<Cidade, ReadCidadeDto>()
                .ForMember(cidadeDto => cidadeDto.Enderecos, option => option.MapFrom(cidade => cidade.Endereco))
                .ForMember(cidadeDto => cidadeDto.UfId, option => option.MapFrom(cidade => cidade.UfId));
            CreateMap<UpdateCidadeDto, Cidade>();
        }
    }
}