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
            CreateMap<Cliente, ReadClienteDto>()
                .ForMember(clienteDto => clienteDto.EnderecoId, opt => opt.MapFrom(cliente => cliente.Enderecos))
                .ForMember(clienteDto => clienteDto.IngressoId, opt => opt.MapFrom(cliente =>
                cliente.Ingressos));
            CreateMap<UpdateClienteDto, Cliente>();
        }
    }
}
