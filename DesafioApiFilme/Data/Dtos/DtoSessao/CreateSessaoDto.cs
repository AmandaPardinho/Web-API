using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoSessao
{
    public class CreateSessaoDto
    {
        [Required]
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
    }
}