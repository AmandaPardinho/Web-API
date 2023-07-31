using AutoMapper;
using DesafioApiFilme.Data.Dtos;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Profiles
{
    public class SessaoProfile: Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();
        }
    }
}
