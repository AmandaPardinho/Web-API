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

        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
