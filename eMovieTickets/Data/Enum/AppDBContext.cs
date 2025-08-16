using eMovieTickets.Models;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovieTickets.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>()
                .HasKey(am => new { am.MovieId, am.ActorId });
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie)
                .WithMany(am => am.Actor_Movie)
                .HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Actor)
                .WithMany(am => am.Actors_Movies)
                .HasForeignKey(a => a.ActorId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
    }
    

