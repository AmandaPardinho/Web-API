using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoUF
{
    public class CreateUfDto
    {
        [Required]
        public string UfId { get; set; }

        [Required]
        public string NomeUf { get; set; }
    }
}
