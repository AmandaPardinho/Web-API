using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título do filme é obrigatório")]
        public string Titulo { get; set; }

        [Required]
        [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
        public int Duracao { get; set; }

        public string Genero { get; set; }
        public virtual Genero Generos { get; set; }

        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}