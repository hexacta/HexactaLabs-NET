using System.Collections.Generic;
using System.Linq;
using MoviesNetCore.Model;

namespace MoviesNetCore.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DatabaseContext db;
        
        public MovieRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Delete(int id)
        {
            var movie = this.Get(id);

            this
                .db
                .Movies
                .Remove(movie);
                
            this.db.SaveChanges();
        }

        public Movie Get(int id)
        {
            return this
                .db
                .Movies
                .Find(id);
        }

        public IEnumerable<Movie> List()
        {
            return this
                .db
                .Movies
                .AsEnumerable();
        }

        public void Update(Movie movie)
        {
            throw new System.NotImplementedException();
        }
    }
}