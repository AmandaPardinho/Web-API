using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoCliente
{
    public class UpdateClienteDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public int Idade { get; set; }
    }
}
