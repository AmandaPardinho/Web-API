using DesafioApiFilme.Models;

namespace DesafioApiFilme.Data.Dtos.DtoIngresso
{
    public class CreateIngressoDto
    {
        public int SessaoId { get; set; }
        
        public int ClienteId { get; set; }
    }
}
