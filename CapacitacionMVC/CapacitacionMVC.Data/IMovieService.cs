namespace CapacitacionMVC.Data
{
    using System;
    using System.Collections.Generic;

    using CapacitacionMVC.Entities;

    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies(Guid? genreIdFilter = null, string nameFilter = null);

        Movie GetMovieById(Guid id);

        void AddMovie(Movie movie);

        void Update(Movie movie);

        void DeleteMovie(Guid id);
    }
}