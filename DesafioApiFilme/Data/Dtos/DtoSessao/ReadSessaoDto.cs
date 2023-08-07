namespace DesafioApiFilme.Data.Dtos.DtoSessao
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public TimeOnly Horario { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
    }
}