using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}
