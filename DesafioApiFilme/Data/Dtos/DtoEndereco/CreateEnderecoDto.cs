using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoEndereco
{
    public class CreateEnderecoDto
    {
        [Required]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }
    }
}
