using AutoMapper;
using DesafioApiFilme.Data.Dtos.DtoGenero;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Profiles
{
    public class GeneroProfile: Profile
    {
        public GeneroProfile()
        {
            CreateMap<CreateGeneroDto, Genero>();
            CreateMap<Genero, ReadGeneroDto>();
            CreateMap<UpdateGeneroDto, Genero>();
        }
    }
}
