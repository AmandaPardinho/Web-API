using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class Cidade
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string NomeCidade { get; set; }

        public string UfId { get; set; }

        public int EnderecoId { get; set; }

        //recupera instâncias
        public virtual Endereco Endereco { get; set; }
        public virtual UF Uf { get; set; }


    }
}
