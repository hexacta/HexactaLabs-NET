namespace CapacitacionMVC.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CapacitacionMVC.Entities;

    public class GenreService : IGenreService
    {
        private readonly MoviesContext moviesContext;

        public GenreService()
        {
            this.moviesContext = new MoviesContext();
        }

        public GenreService(MoviesContext context)
        {
            this.moviesContext = context;
        }

        public IEnumerable<Genre> GetGenres(string filter = null)
        {
            var genres = this.moviesContext.Genres.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                genres = genres.Where(w => w.Name.ToLower().Contains(filter.ToLower()));
            }

            return genres.OrderBy(o => o.Name);
        }

        public Genre GetGenreById(Guid id)
        {
            return this.moviesContext.Genres.FirstOrDefault(f => f.Id == id);
        }
    }
}