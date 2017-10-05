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

        public void Delete(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Movie Get(int id)
        {
            throw new System.NotImplementedException();
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