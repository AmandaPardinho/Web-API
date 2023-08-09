using AutoMapper;
using DesafioApiFilme.Data.Dtos.DtoCliente;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Profiles
{
    public class ClienteProfile: Profile
    {
        public ClienteProfile()

        {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<Cliente, ReadClienteDto>();
            CreateMap<UpdateClienteDto, Cliente>();
        }
    }
}
