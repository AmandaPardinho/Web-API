using DesafioApiFilme.Data.Dtos.DtoFilme;
using DesafioApiFilme.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoGenero
{
    public class ReadGeneroDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }       
    }
}
