using Microsoft.EntityFrameworkCore;
using MoviesNetCore.Model;

namespace MoviesNetCore.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<MovieGenre>()
                .HasKey(x => new { x.MovieId, x.GenreId });
        }
    }
}