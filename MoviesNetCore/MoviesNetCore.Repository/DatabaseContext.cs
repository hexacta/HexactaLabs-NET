using Microsoft.EntityFrameworkCore;

namespace MoviesNetCore.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesNetCore.Model.Movie> Movie { get; set; }
    }
}