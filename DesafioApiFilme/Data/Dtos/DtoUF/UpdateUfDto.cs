using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoUF
{
    public class UpdateUfDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}