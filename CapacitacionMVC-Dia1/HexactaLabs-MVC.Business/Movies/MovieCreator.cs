using HexactaLabs_MVC.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexactaLabs_MVC.Business.Movies
{
    public class MovieCreator
    {
        private readonly IRepository<Movie> movieRepository;


        public MovieCreator(IRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public void Create(Movie movie)
        {
            this.movieRepository.Save(movie);
        }

        public void Edit(Movie movieEdited)
        {
            var movie = this.movieRepository.Find(movieEdited.Id);

            movie.Name = movieEdited.Name;
            movie.CoverLink = movieEdited.CoverLink;
            movie.Plot = movieEdited.Plot;
            movie.ReleaseDate = movieEdited.ReleaseDate;
            movie.Genres.Clear();

            foreach (var genre in movieEdited.Genres)
            {
                movie.Genres.Add(genre);
            }

            this.movieRepository.Update(movie);
        }

        public void Delete(int id)
        {
            var movie = this.movieRepository.Find(id);

            this.movieRepository.Delete(movie);
        }
    }
}
