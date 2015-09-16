using HexactaLabs_MVC.Business.Genres;
using HexactaLabs_MVC.Business.Movies;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexactaLabs_MVC.Persistence.Common
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            Database.SetInitializer<MoviesContext>(new DBInitializer<MoviesContext>());

            modelBuilder
               .Entity<Movie>()
               .HasMany(c => c.Genres)
               .WithMany()
               .Map(m =>
               {
                   m.MapLeftKey("MovieId");
                   m.MapRightKey("GenreId");
                   m.ToTable("MovieGenre");
               });

            base.OnModelCreating(modelBuilder);
        }
    }
}
