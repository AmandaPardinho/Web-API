using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public TimeOnly Horario { get; set; }

        public int? FilmeId { get; set; }
        public virtual Filme Filme { get; set; }

        public int? CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

        public int? IngressoId { get; set; }
        public virtual ICollection<Ingresso> Ingressos { get; set; }

    }
}