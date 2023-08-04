using DesafioApiFilme.Data.Dtos.DtoEndereco;
using DesafioApiFilme.Data.Dtos.DtoSessao;

namespace DesafioApiFilme.Data.Dtos.DtoCinema
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
        public ICollection<ReadSessaoDto> Sessoes { get; set; }
    }
}