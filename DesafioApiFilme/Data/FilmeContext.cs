using DesafioApiFilme.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioApiFilme.Data
{
    public class FilmeContext: DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts): base(opts) 
        {
            
        }

        //relacionamentos entre entidades
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //sessão
            builder.Entity<Sessao>()
                .HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId)
                .OnDelete(DeleteBehavior.Restrict);

            //endereço
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)                
                .WithOne(cinema => cinema.Endereco)                
                .HasPrincipalKey<Endereco>(endereco => endereco.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //uf
            builder.Entity<UF>()
                .HasMany(uf => uf.Cidade)
                .WithOne(cidade => cidade.Uf)
                .HasPrincipalKey(uf => uf.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<UF> Ufs { get; set; }
    }
}