using System.ComponentModel.DataAnnotations;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Data.Dtos.DtoUF
{
    public class ReadUfDto
    {
        public string UfId { get; set; }
        public string NomeUf { get; set; }
        public int CidadeId { get; set; }
        public virtual ICollection<Cidade> Cidade { get; set; }
    }
}
