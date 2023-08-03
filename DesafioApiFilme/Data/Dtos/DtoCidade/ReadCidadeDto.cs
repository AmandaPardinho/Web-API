using DesafioApiFilme.Data.Dtos.DtoEndereco;

namespace DesafioApiFilme.Data.Dtos.DtoCidade
{
    public class ReadCidadeDto
    {
        public int CidadeId { get; set; }
        public string NomeCidade { get; set; }
        public string UfId { get; set; }
        public ICollection<ReadEnderecoDto> Enderecos { get; set; }
    }
}
