using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class UF
    {
        [Key]
        [Required]
        public string UfId { get; set; }

        [Required]
        public string NomeUf { get; set; }

        public virtual ICollection<Cidade> Cidade { get; set; }

        //public UF()
        //{
        //    var id = UfId;
        //    var idMaiusculo = id.ToUpper();

        //    var nome = NomeUf;
        //    var nomeMaiusculo = nome.ToUpper();

        //}
    }
}
