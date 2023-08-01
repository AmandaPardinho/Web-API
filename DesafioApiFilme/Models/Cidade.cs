using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class Cidade
    {
        [Key]
        [Required]
        public int CidadeId { get; set; }

        [Required]
        public string NomeCidade { get; set; }       

        public int EnderecoId { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }

        public string UfId { get; set; }
        public virtual UF Uf { get; set; }
    }
}
