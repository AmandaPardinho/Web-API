using AutoMapper;
using DesafioApiFilme.Data.Dtos;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Profiles
{
    public class EnderecoProfile: Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<UpdateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}
