using DesafioApiFilme.Data.Dtos.DtoEndereco;

namespace DesafioApiFilme.Data.Dtos.DtoCidade
{
    public class ReadCidadeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UfId { get; set; }
        public ICollection<ReadEnderecoDto> Enderecos { get; set; }
    }
}