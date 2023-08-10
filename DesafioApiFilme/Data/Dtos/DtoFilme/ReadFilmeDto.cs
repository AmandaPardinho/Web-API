using DesafioApiFilme.Data.Dtos.DtoSessao;

namespace DesafioApiFilme.Data.Dtos.DtoFilme
{
    public class ReadFilmeDto
    {
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
        public int? GeneroId { get; set; }
        public ICollection<ReadSessaoDto> Sessoes { get; set; }
    }
}