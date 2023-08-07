using DesafioApiFilme.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoCliente
{
    public class CreateClienteDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public int Idade { get; set; }

        public string Endereco { get; set; }
    }
}
