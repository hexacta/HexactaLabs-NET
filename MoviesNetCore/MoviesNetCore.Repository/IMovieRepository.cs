using System.Collections.Generic;
using MoviesNetCore.Model;

namespace MoviesNetCore.Repository
{
    public interface IMovieRepository
    {
        Movie Get(int id);

        IEnumerable<Movie> List();

        void Update(Movie movie);

        void Delete(int id);
    }
}