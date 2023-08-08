using System.Data.SqlTypes;

namespace DesafioApiFilme.Data.Dtos.DtoSessao
{
    public class UpdateSessaoDto
    {
        public DateTime Horario { get; set; }
        public int FilmeId { get; set; }
    }
}
