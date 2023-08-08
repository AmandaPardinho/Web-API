using System.Data.SqlTypes;

namespace DesafioApiFilme.Data.Dtos.DtoSessao
{
    public class UpdateSessaoDto
    {
        public SqlDateTime Horario { get; set; }
        public int FilmeId { get; set; }
    }
}
