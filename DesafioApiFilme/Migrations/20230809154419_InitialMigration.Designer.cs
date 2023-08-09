﻿// <auto-generated />
using System;
using DesafioApiFilme.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioApiFilme.Migrations
{
    [DbContext(typeof(FilmeContext))]
    [Migration("20230809154419_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DesafioApiFilme.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UfId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UfId");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("ClienteId")
                        .IsUnique()
                        .HasFilter("[ClienteId] IS NOT NULL");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<int?>("GeneroId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId")
                        .IsUnique();

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Ingresso", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("SessaoId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "SessaoId");

                    b.HasIndex("SessaoId");

                    b.ToTable("Ingressos");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Sessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CinemaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("FilmeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Horario")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("FilmeId");

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.UF", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ufs");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Cidade", b =>
                {
                    b.HasOne("DesafioApiFilme.Models.UF", "Uf")
                        .WithMany("Cidade")
                        .HasForeignKey("UfId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Uf");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Cinema", b =>
                {
                    b.HasOne("DesafioApiFilme.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Endereco", b =>
                {
                    b.HasOne("DesafioApiFilme.Models.Cidade", "Cidade")
                        .WithMany("Endereco")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesafioApiFilme.Models.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("DesafioApiFilme.Models.Endereco", "ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Cidade");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Filme", b =>
                {
                    b.HasOne("DesafioApiFilme.Models.Genero", "Genero")
                        .WithOne("Filmes")
                        .HasForeignKey("DesafioApiFilme.Models.Filme", "GeneroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Ingresso", b =>
                {
                    b.HasOne("DesafioApiFilme.Models.Cliente", "Cliente")
                        .WithMany("Ingressos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DesafioApiFilme.Models.Sessao", "Sessao")
                        .WithMany("Ingressos")
                        .HasForeignKey("SessaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Sessao");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Sessao", b =>
                {
                    b.HasOne("DesafioApiFilme.Models.Cinema", "Cinema")
                        .WithMany("Sessoes")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesafioApiFilme.Models.Filme", "Filme")
                        .WithMany("Sessoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Cidade", b =>
                {
                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Cinema", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Cliente", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Ingressos");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Filme", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Genero", b =>
                {
                    b.Navigation("Filmes")
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioApiFilme.Models.Sessao", b =>
                {
                    b.Navigation("Ingressos");
                });

            modelBuilder.Entity("DesafioApiFilme.Models.UF", b =>
                {
                    b.Navigation("Cidade");
                });
#pragma warning restore 612, 618
        }
    }
}
