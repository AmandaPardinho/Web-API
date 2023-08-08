using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace DesafioApiFilme.Data.Dtos.DtoSessao
{
    public class CreateSessaoDto
    {
        [Required]
        public SqlDateTime Horario { get; set; }

        [Required]
        public int FilmeId { get; set; }

        public int CinemaId { get; set; }
    }
}