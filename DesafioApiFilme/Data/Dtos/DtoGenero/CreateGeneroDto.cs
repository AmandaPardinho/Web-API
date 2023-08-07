using DesafioApiFilme.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoGenero
{
    public class CreateGeneroDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public int FilmeId { get; set; }
    }
}
