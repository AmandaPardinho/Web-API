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
            //genero
            builder.Entity<Genero>()
                .HasOne(genero => genero.Filmes)
                .WithOne(filme => filme.Generos)
                .HasPrincipalKey<Genero>(genero => genero.Id)
                .OnDelete(DeleteBehavior.Restrict);
            
            //cliente
            //builder.Entity<Cliente>()
            //    .HasMany(cliente => cliente.Ingressos)
            //    .WithOne(ingresso => ingresso.Cliente)
            //    .HasPrincipalKey(cliente => cliente.Id)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Cliente>()
                .HasMany(cliente => cliente.Enderecos)
                .WithOne(endereco => endereco.Cliente)
                .HasPrincipalKey(cliente => cliente.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //ingresso
            builder.Entity<Ingresso>()
                .HasKey(ingresso => new { ingresso.ClienteId, ingresso.SessaoId });

            builder.Entity<Ingresso>()
                .HasOne(ingresso => ingresso.Cliente)
                .WithMany(cliente => cliente.Ingressos)
                .HasForeignKey(ingresso => ingresso.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);     
            
            //sessão
            builder.Entity<Sessao>()
                .HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId, sessao.IngressoId });

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Sessao>()
                .HasMany(sessao => sessao.Ingressos)
                .WithOne(ingresso => ingresso.Sessao)
                .HasPrincipalKey(sessao => sessao.Id)
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
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<UF> Ufs { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ingresso> Ingressos { get; set; }
    }
}