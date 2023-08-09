using DesafioApiFilme.Data.Dtos.DtoEndereco;
using DesafioApiFilme.Data.Dtos.DtoIngresso;
using DesafioApiFilme.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoCliente
{
    public class ReadClienteDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sexo { get; set; }

        public int Idade { get; set; }

        public int EnderecoId { get; set; }
    }
}
