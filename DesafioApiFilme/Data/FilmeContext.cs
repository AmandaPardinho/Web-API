using DesafioApiFilme.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DesafioApiFilme.Data
{
    public class FilmeContext: DbContext
    {
        public FilmeContext()
        {
            
        }
        public FilmeContext(DbContextOptions<FilmeContext> opts): base(opts) 
        {
            
        }

        //relacionamentos entre entidades
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //cliente
            builder.Entity<Cliente>()
                .HasOne(cliente => cliente.Endereco)
                .WithOne(endereco => endereco.Cliente)
                .HasPrincipalKey<Cliente>(cliente => cliente.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //genero
            builder.Entity<Genero>()
                .HasMany(genero => genero.Filmes)
                .WithOne(filme => filme.Genero)
                .HasForeignKey(filme => filme.GeneroId)
                .OnDelete(DeleteBehavior.Restrict);

            //ingresso
            builder.Entity<Ingresso>()
                .HasKey(ingresso => new { ingresso.ClienteId, ingresso.SessaoId });

            builder.Entity<Ingresso>()
                .HasOne(ingresso => ingresso.Cliente)
                .WithMany(cliente => cliente.Ingressos)
                .HasForeignKey(ingresso => ingresso.ClienteId)
                .HasPrincipalKey(ingresso => ingresso.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ingresso>()
                .HasOne(ingresso => ingresso.Sessao)
                .WithMany(sessao => sessao.Ingressos)
                .HasForeignKey(ingresso => ingresso.SessaoId)
                .HasPrincipalKey(ingresso => ingresso.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //sessão
            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId)
                .HasPrincipalKey(sessao => sessao.Id);

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId)
                .HasPrincipalKey(sessao => sessao.Id)
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
        public DbSet<Proc> Procs { get; set; }
    }
}