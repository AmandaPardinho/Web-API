using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class UF
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string NomeUf { get; set; }
    }
}
