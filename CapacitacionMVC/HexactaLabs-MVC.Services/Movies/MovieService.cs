using HexactaLabs_MVC.Business.Common;
using HexactaLabs_MVC.Business.Movies;
using HexactaLabs_MVC.Dtos.Movies;
using HexactaLabs_MVC.IServices.Movies;
using System.Linq;

namespace HexactaLabs_MVC.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public MovieDto GetMovie(int id)
        {
            var movie = movieRepository.First(x => x.Id == id);

            if (movie == null)
            {
                return null;
            }

            //TODO: REFACTOR - De que otra manera se podria hacer?
            return new MovieDto()
            {
                Id = movie.Id,
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                Plot = movie.Plot,
                CoverLink = movie.CoverLink,
                Runtime = movie.Runtime,
                GenresIds = movie.Genres.Select(x => x.Id).ToList()
            };
        }
    }
}
