using HexactaLabs_MVC.Dtos.Movies;
using HexactaLabs_MVC.IServices.Genres;
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
        private readonly IGenreService genreService;

        public MoviesController(
            IMovieService movieService,
            IGenreService genreService)
        {
            this.movieService = movieService;
            this.genreService = genreService;
        }


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


        [HttpGet]
        public ActionResult Create()
        {
            this.ViewData.Model = new MovieViewModel();
            this.ViewBag.Genres = this.genreService.GetAll();
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(MovieViewModel movie, IEnumerable<int> selectedGenres)
        {
            if (this.ModelState.IsValid)
            {

                var movieDto = new MovieDto
                {
                    Name = movie.Name,
                    CoverLink = movie.CoverLink,
                    Plot = movie.Plot,
                    ReleaseDate = movie.ReleaseDate.Value,
                    Runtime = movie.Runtime.Value,
                    GenresIds = selectedGenres.ToList()
                };

                this.movieService.Create(movieDto);
                this.TempData["successmessage"] = "Se ha agregado exitosamente la pelicula: " + movie.Name;
                return RedirectToAction("Index");
            }

            return this.View(movie);
        }



        public ActionResult Edit(int id)
        {
            var movie = movieService.GetMovie(id);

            var movieVM = new MovieViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                CoverLink = movie.CoverLink,
                Plot = movie.Plot,
                ReleaseDate = movie.ReleaseDate,
                Runtime = movie.Runtime,
                Genres = movie.GenresIds
            };

            this.ViewBag.Genres = this.genreService.GetAll();

            return View(movieVM);
        }

        [HttpPost]
        public ActionResult Edit(MovieViewModel movie, IEnumerable<int> selectedGenres)
        {
            if (this.ModelState.IsValid)
            {

                var movieDto = new MovieDto
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    CoverLink = movie.CoverLink,
                    Plot = movie.Plot,
                    ReleaseDate = movie.ReleaseDate.Value,
                    Runtime = movie.Runtime.Value,
                    GenresIds = selectedGenres.ToList()
                };

                this.movieService.Edit(movieDto);
                this.TempData["successmessage"] = "Se ha editado exitosamente la pelicula: " + movie.Name;
                return RedirectToAction("Index");
            }

            return this.View(movie);
        }




        public ActionResult Delete(int id)
        {
            var movie = movieService.GetMovie(id);
            
            this.movieService.Delete(id);
            
            this.TempData["successmessage"] = "Se ha eliminado exitosamente la pelicula: " + movie.Name;

            return RedirectToAction("Index");
        }

    }
}