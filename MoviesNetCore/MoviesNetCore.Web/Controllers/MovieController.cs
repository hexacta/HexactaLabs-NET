using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoviesNetCore.Model;
using MoviesNetCore.Repository;
using MoviesNetCore.Web.Models;

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
            var model = this.CreateViewModel(movies);
            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            var movie = this.movieRepository.Get(id);

            var model = this.CreateViewModel(movie);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(MovieViewModel model)
        {
            this.movieRepository.Delete(model.Id);

            return this.RedirectToAction("Index", "Movie");
        }

        private IList<MovieViewModel> CreateViewModel(IEnumerable<Movie> movies)
        {
            var moviesList = new List<MovieViewModel>();

            foreach (var item in movies)
            {
                MovieViewModel model = this.CreateViewModel(item);
                moviesList.Add(model);

            }
            return moviesList;
        }

        private MovieViewModel CreateViewModel(Movie item)
        {
            var movieViewModel = new MovieViewModel();

            movieViewModel.Id = item.Id;
            movieViewModel.Name = item.Name;
            movieViewModel.Plot = item.Plot;
            movieViewModel.ReleaseDate = item.ReleaseDate;
            movieViewModel.Runtime = item.Runtime;
            movieViewModel.CoverLink = item.CoverLink;

            return movieViewModel;
        }
    }
}