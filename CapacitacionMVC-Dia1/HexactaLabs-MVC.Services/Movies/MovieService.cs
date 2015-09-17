using HexactaLabs_MVC.Business.Common;
using HexactaLabs_MVC.Business.Genres;
using HexactaLabs_MVC.Business.Movies;
using HexactaLabs_MVC.Dtos.Movies;
using HexactaLabs_MVC.IServices.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexactaLabs_MVC.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> movieRepository;
        private readonly IRepository<Genre> genreRepository;
        private readonly MovieCreator movieCreator;

        public MovieService(IRepository<Movie> movieRepository,
            IRepository<Genre> genreRepository,
            MovieCreator movieCreator)
        {
            this.movieRepository = movieRepository;
            this.genreRepository = genreRepository;
            this.movieCreator = movieCreator;
        }

        public MovieDto GetMovie(int id)
        {
            Movie movie = movieRepository.First(x => x.Id == id);

            return Map(movie);
        }
        
        public IEnumerable<MovieDto> GetAll()
        {
            return movieRepository.GetAll().Select(x => Map(x));
        }

        public IEnumerable<MovieDto> GetBy(string name, int? genreId)
        {
                return movieRepository.Get(x => 
                            ((name == null) ||  (name!=null && x.Name.ToLower().Contains(name.ToLower()))) &&
                            (!genreId.HasValue || genreId.HasValue && x.Genres.Any(g => g.Id == genreId.Value))
                    
                 ).Select(x => Map(x));
        }



        public void Create(MovieDto movieDto)
        {
            var movie = this.Map(movieDto);
            this.movieCreator.Create(movie);
        }

        public void Edit(MovieDto movieDto)
        {
            var movie = this.Map(movieDto);
            this.movieCreator.Edit(movie);
        }

        public void Delete(int id)
        {
            this.movieCreator.Delete(id);
        }



        private MovieDto Map(Movie movie)
        {
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

        private Movie Map(MovieDto movieDto)
        {

            var genres = this.genreRepository.GetAll();

            return new Movie()
            {
                Id = movieDto.Id,
                Name = movieDto.Name,
                ReleaseDate = movieDto.ReleaseDate,
                Plot = movieDto.Plot,
                CoverLink = movieDto.CoverLink,
                Runtime = movieDto.Runtime,
                Genres = genres.Where(g => movieDto.GenresIds.Contains(g.Id)).ToList()
            };
        }      
      
    }
}
