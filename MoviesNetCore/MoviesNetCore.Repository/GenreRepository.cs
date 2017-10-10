using System.Collections.Generic;
using System.Linq;
using MoviesNetCore.Model;

namespace MoviesNetCore.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DatabaseContext db;
        
        public GenreRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Genre Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Genre> List()
        {
            return this
                .db
                .Genres
                .AsEnumerable();
        }

        public void Update(Genre genre)
        {
            throw new System.NotImplementedException();
        }
    }
}