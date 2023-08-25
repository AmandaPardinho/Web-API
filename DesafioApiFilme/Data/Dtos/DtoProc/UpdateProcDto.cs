using DesafioApiFilme.Data.Dtos.DtoCinema;
using DesafioApiFilme.Data.Dtos.DtoCliente;
using DesafioApiFilme.Data.Dtos.DtoFilme;
using DesafioApiFilme.Data.Dtos.DtoGenero;

namespace DesafioApiFilme.Data.Dtos.DtoProc
{
    public class UpdateProcDto
    {
        public string? Nome { get; set; }
        public int? Idade { get; set; }
        public string? Cinema { get; set; }
        public string? Filme { get; set; }
        public string? Genero { get; set; }
    }
}
