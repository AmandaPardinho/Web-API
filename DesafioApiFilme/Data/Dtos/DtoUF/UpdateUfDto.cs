using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoUF
{
    public class UpdateUfDto
    {
        [Required]
        public string UfId { get; set; }

        [Required]
        public string NomeUf { get; set; }
    }
}
