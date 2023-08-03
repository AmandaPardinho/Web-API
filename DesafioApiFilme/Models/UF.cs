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


        //usar tabela ASCII
        //public UF()
        //{
        //    List<string> estado = new List<string>();

        //    estado.Add("Sao Paulo");

        //    List<char> siglaEstado = new List<char>();

        //}

    }
}
