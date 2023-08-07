using DesafioApiFilme.Data.Dtos.DtoCliente;
using DesafioApiFilme.Data.Dtos.DtoSessao;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Data.Dtos.DtoIngresso
{
    public class ReadIngressoDto
    {
        public int Id { get; set; }

        public int SessaoId { get; set; }

        public int ClienteId { get; set; }
    }
}
