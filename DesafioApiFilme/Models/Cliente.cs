using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public int Idade { get; set; }

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual ICollection<Ingresso> Ingressos { get; set; }
    }
}
