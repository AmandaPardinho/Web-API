using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DesafioApiFilme.Models
{
    [Keyless]
    public class Proc
    {
        public string? Nome { get; set; }        
        public int? Idade { get; set; }
        public virtual IEnumerable<Cliente> Cliente { get; set; }

        public string? Cinema { get; set; }
        public virtual IEnumerable<Cinema> Cinemas { get; set; }

        public string? Filme { get; set; }
        public virtual IEnumerable<Filme> Filmes { get; set; }

        public string? Genero { get; set; }
        public virtual IEnumerable<Genero> Generos { get; set; }
    }
}
