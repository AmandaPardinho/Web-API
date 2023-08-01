using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoCinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
