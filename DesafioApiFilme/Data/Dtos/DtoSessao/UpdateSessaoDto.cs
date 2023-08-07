namespace DesafioApiFilme.Data.Dtos.DtoSessao
{
    public class UpdateSessaoDto
    {
        public TimeOnly Horario { get; set; }
        public int FilmeId { get; set; }
    }
}
