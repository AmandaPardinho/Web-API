using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoCidade
{
    public class UpdateCidadeDto
    {
        [Required]
        public int CidadeId { get; set; }

        [Required]
        public string NomeCidade { get; set; }
    }
}
