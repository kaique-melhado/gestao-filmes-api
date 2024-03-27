using GestaoFilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoFilmesAPI.Data
{
    public class GestaoFilmesContext : DbContext
    {
        public GestaoFilmesContext(DbContextOptions<GestaoFilmesContext> opts) : base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sessao>()
                .HasKey(sessao => new { sessao.IdFilme, sessao.IdCinema });

            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.IdCinema);

            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.IdFilme);

            modelBuilder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}
