using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int EnderecoId { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
    }
}
