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
            CreateMap<UF, ReadUfDto>(); 
            CreateMap<UpdateUfDto, UF>();
        }
    }
}