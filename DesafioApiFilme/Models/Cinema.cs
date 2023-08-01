using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public int SessaoId { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
