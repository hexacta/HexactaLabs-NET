using HexactaLabs_MVC.IServices.Movies;
using HexactaLabs_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HexactaLabs_MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        // GET: Movies
        public ActionResult Index(int? genreId, string filter)
        {
            @TempData["MovieList"] = this.movieService.GetBy(filter, genreId);

            return View(new MovieSearchViewModel() { GenreId = genreId, Filter = filter });
        }
        
        public ActionResult Detail(int id)
        {
            var movie = movieService.GetMovie(id);

            return View(movie);
        }

    }
}