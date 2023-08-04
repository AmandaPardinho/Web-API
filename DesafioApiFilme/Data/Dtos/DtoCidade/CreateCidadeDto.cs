using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoCidade
{
    public class CreateCidadeDto
    {
        [Required]
        public string Nome { get; set; }

        public string UfId { get; set; }
    }
}