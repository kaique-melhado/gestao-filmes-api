﻿// <auto-generated />
using GestaoFilmesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestaoFilmesAPI.Migrations
{
    [DbContext(typeof(GestaoFilmesContext))]
    [Migration("20240124235441_SessaoFilme")]
    partial class SessaoFilme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GestaoFilmesAPI.Models.Cinema", b =>
                {
                    b.Property<int>("IdCinema")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("NomeCinema")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("IdCinema");

                    b.HasIndex("IdEndereco")
                        .IsUnique();

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("GestaoFilmesAPI.Models.Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("IdEndereco");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("GestaoFilmesAPI.Models.Filme", b =>
                {
                    b.Property<int>("IdFilme")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("IdFilme");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("GestaoFilmesAPI.Models.Sessao", b =>
                {
                    b.Property<int>("IdSessao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CinemaIdCinema")
                        .HasColumnType("int");

                    b.Property<int>("FilmeIdFilme")
                        .HasColumnType("int");

                    b.Property<int>("IdCinema")
                        .HasColumnType("int");

                    b.Property<int>("IdFilme")
                        .HasColumnType("int");

                    b.HasKey("IdSessao");

                    b.HasIndex("CinemaIdCinema");

                    b.HasIndex("FilmeIdFilme");

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("GestaoFilmesAPI.Models.Cinema", b =>
                {
                    b.HasOne("GestaoFilmesAPI.Models.Endereco", "Endereco")
                        .WithOne("Cinema")
                        .HasForeignKey("GestaoFilmesAPI.Models.Cinema", "IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("GestaoFilmesAPI.Models.Sessao", b =>
                {
                    b.HasOne("GestaoFilmesAPI.Models.Cinema", "Cinema")
                        .WithMany("Sessoes")
                        .HasForeignKey("CinemaIdCinema")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestaoFilmesAPI.Models.Filme", "Filme")
                        .WithMany("Sessoes")
                        .HasForeignKey("FilmeIdFilme")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("GestaoFilmesAPI.Models.Cinema", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("GestaoFilmesAPI.Models.Endereco", b =>
                {
                    b.Navigation("Cinema")
                        .IsRequired();
                });

            modelBuilder.Entity("GestaoFilmesAPI.Models.Filme", b =>
                {
                    b.Navigation("Sessoes");
                });
#pragma warning restore 612, 618
        }
    }
}
