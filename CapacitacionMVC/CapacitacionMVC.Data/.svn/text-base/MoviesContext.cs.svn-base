namespace CapacitacionMVC.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using CapacitacionMVC.Entities;

    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("MoviesContext")
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MoviesContext>(null);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Entity<Movie>()
                .HasMany(c => c.Genres)
                .WithMany(p => p.Movies)
                .Map(m =>
                {
                    m.MapLeftKey("MovieId");
                    m.MapRightKey("GenreId");
                    m.ToTable("Movie_Genre");
                });
        }
    }
}