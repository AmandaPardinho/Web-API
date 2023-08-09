using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoFilme
{
    public class UpdateFilmeDto
    {
        public string Titulo { get; set; }

        public int Duracao { get; set; }
    }
}