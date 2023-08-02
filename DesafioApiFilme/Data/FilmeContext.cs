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
                .HasForeignKey(sessao => sessao.FilmeId);

            //endereço
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)                
                .WithOne(cinema => cinema.Endereco)                
                .HasPrincipalKey<Endereco>(endereco => endereco.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);

            //cidade
            builder.Entity<Cidade>()
                .HasKey(cidade => new { cidade.EnderecoId, cidade.UfId });

            builder.Entity<Cidade>()
                .HasOne(cidade => cidade.Uf)
                .WithMany(uf => uf.Cidade)
                .HasForeignKey(cidade => cidade.UfId)
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


//////filme
////builder.Entity<Filme>()
////    .HasKey(filme => new {filme.FilmeId, filme.SessaoId});

////builder.Entity<Filme>()
////    .HasMany(filme => filme.Sessoes)
////    .WithOne(sessao =>  sessao.Filme)
////    .HasForeignKey(filme => filme.SessaoId)
////    .OnDelete(DeleteBehavior.Restrict);

////sessão
//builder.Entity<Sessao>()
//    .HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });

//builder.Entity<Sessao>()
//    .HasOne(sessao => sessao.Cinema)
//    .WithMany(cinema => cinema.Sessoes)
//    .HasForeignKey(sessao => sessao.CinemaId);

//builder.Entity<Sessao>()
//    .HasOne(sessao => sessao.Filme)
//    .WithMany(filme => filme.Sessoes)
//    .HasForeignKey(sessao => sessao.FilmeId);

////cinema
////builder.Entity<Cinema>()
////    .HasKey(cinema => new { cinema.CinemaId, cinema.SessaoId, cinema.EnderecoId });

////builder.Entity<Cinema>()
////    .HasMany(cinema => cinema.Sessoes)
////    .WithOne(sessao => sessao.Cinema)
////    .HasForeignKey(cinema => cinema.SessaoId)
////    .OnDelete(DeleteBehavior.Restrict);

////builder.Entity<Cinema>()
////    .HasOne(cinema => cinema.Endereco)
////    .WithOne(endereco => endereco.Cinema)
////    .OnDelete(DeleteBehavior.Restrict);

////endereço
////builder.Entity<Endereco>()
////    .HasKey(endereco => new {endereco.EnderecoId, endereco.CinemaId, endereco.CidadeId});

//builder.Entity<Endereco>()
//    .HasOne(endereco => endereco.Cinema)
//    .WithOne(cinema => cinema.Endereco)
//    .OnDelete(DeleteBehavior.Restrict);

////builder.Entity<Endereco>()
////    .HasOne(endereco => endereco.Cidade)
////    .WithMany(cidade => cidade.Endereco)
////    .HasForeignKey(endereco => endereco.CidadeId)
////    .OnDelete(DeleteBehavior.Restrict);

//////cidade
////builder.Entity<Cidade>()
////    .HasKey(cidade => new {cidade.CidadeId, cidade.EnderecoId, cidade.UfId});

////builder.Entity<Cidade>()
////    .HasMany(cidade => cidade.Endereco)
////    .WithOne(endereco => endereco.Cidade)
////    .HasForeignKey(cidade => cidade.EnderecoId)
////    .OnDelete(DeleteBehavior.Restrict);

////builder.Entity<Cidade>()
////    .HasOne(cidade => cidade.Uf)
////    .WithMany(uf => uf.Cidade)
////    .HasForeignKey(cidade => cidade.UfId)
////    .OnDelete(DeleteBehavior.Restrict);

//////uf
////builder.Entity<UF>()
////    .HasKey(uf => new { uf.UfId, uf.CidadeId });

////builder.Entity<UF>()
////    .HasMany(uf => uf.Cidade)
////    .WithOne(cidade => cidade.Uf)
////    .HasForeignKey(uf => uf.CidadeId)
////    .OnDelete(DeleteBehavior.Restrict);