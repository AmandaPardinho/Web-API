using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoCliente
{
    public class UpdateClienteDto
    {
        public string Nome { get; set; }

        public string Sexo { get; set; }

        public int Idade { get; set; }

        public int EnderecoId { get; set; }
    }
}
