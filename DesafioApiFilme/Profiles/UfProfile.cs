using AutoMapper;
using DesafioApiFilme.Data.Dtos.DtoUF;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Profiles
{
    public class UfProfile: Profile
    {
        public UfProfile()
        {
            CreateMap<CreateUfDto, UF>();
            CreateMap<UF, ReadUfDto>()
                .ForMember(ufDto => ufDto.Cidade, option => option.MapFrom(uf => uf.Cidade));
            CreateMap<UpdateUfDto, UF>();
        }
    }
}
