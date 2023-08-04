using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class UF
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public int CidadeId { get; set; }
        public virtual ICollection<Cidade> Cidade { get; set; }
    }
}