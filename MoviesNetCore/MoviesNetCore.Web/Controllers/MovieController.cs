using Microsoft.AspNetCore.Mvc;
using MoviesNetCore.Repository;

namespace MoviesNetCore.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            var movies = this.movieRepository.List();
            return this.View(movies);
        }
    }
}