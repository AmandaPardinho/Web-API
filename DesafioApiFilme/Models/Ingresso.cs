using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class Ingresso
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int SessaoId { get; set; }
        public virtual Sessao Sessao { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
