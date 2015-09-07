namespace CapacitacionMVC.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using CapacitacionMVC.Data;
    using CapacitacionMVC.Entities;
    using CapacitacionMVC.Web.Models;

    public class MoviesController : Controller
    {
        private readonly MovieService movieService;
        private readonly GenreService genreService;

        public MoviesController()
        {
            var context = new MoviesContext();
            this.movieService = new MovieService(context);
            this.genreService = new GenreService(context);
        }

        public ActionResult Index(Guid? genreId = null, string searchText = null)
        {
            return this.View(new MoviesIndexModel { Movies = this.movieService.GetMovies(genreId, searchText), SearchText = searchText, GenreId = genreId });
        }

        public ActionResult Details(Guid id)
        {
            var movie = this.movieService.GetMovieById(id);

            return this.View(new MoviesDetailsModel { Movie = movie });
        }

        public ActionResult Create()
        {
            return this.View(new MoviesCreateModel() { ViewAction = ViewAction.Create, Movie = new Movie(), Genres = this.genreService.GetGenres() });
        }

        [HttpPost]
        public ActionResult Create(Movie movie, IEnumerable<Guid> selectedGenres)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Ha ocurrido un error al guardar la pelicula");
                    return this.View(new MoviesCreateModel() { ViewAction = ViewAction.Create, Movie = movie, Genres = this.genreService.GetGenres() });
                }

                movie.Id = Guid.NewGuid();

                if (selectedGenres != null)
                {
                    foreach (var selectedGenreId in selectedGenres)
                    {
                        var genre = this.genreService.GetGenreById(selectedGenreId);

                        if (genre != null)
                        {
                            movie.Genres.Add(genre);
                        }
                    }
                }

                this.movieService.AddMovie(movie);

                this.TempData["successmessage"] = "Se ha agregado exitosamente la pelicula: " + movie.Name;

                return this.RedirectToAction("Index");
            }
            catch
            {
                this.ModelState.AddModelError(string.Empty, "Ha ocurrido un error al guardar la pelicula");
                return this.View(new MoviesCreateModel() { ViewAction = ViewAction.Create, Movie = movie, Genres = this.genreService.GetGenres() });
            }
        }

        public ActionResult Edit(Guid id)
        {
            var movie = this.movieService.GetMovieById(id);

            return this.View("Create", new MoviesCreateModel() { ViewAction = ViewAction.Edit, Movie = movie, Genres = this.genreService.GetGenres() });
        }

        [HttpPost]
        public ActionResult Edit(Movie movie, IEnumerable<Guid> selectedGenres)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Ha ocurrido un error al guardar la pelicula");
                    return this.View("Create", new MoviesCreateModel() { ViewAction = ViewAction.Edit, Movie = movie, Genres = this.genreService.GetGenres() });
                }

                var movieDb = this.movieService.GetMovieById(movie.Id);

                movieDb.Name = movie.Name;
                movieDb.ReleaseDate = movie.ReleaseDate;
                movieDb.Runtime = movie.Runtime;
                movieDb.CoverLink = movie.CoverLink;
                movieDb.Plot = movie.Plot;

                if (selectedGenres != null)
                {
                    movieDb.Genres.Clear();

                    foreach (var selectedGenreId in selectedGenres)
                    {
                        var genre = this.genreService.GetGenreById(selectedGenreId);

                        if (genre != null)
                        {
                            movieDb.Genres.Add(genre);
                        }
                    }
                }

                this.movieService.Update(movie);

                this.TempData["successmessage"] = "Se ha actualizado exitosamente la pelicula: " + movie.Name;

                return this.RedirectToAction("Index");
            }
            catch
            {
                this.ModelState.AddModelError(string.Empty, "Ha ocurrido un error al guardar la pelicula");
                return this.View("Create", new MoviesCreateModel() { ViewAction = ViewAction.Edit, Movie = movie, Genres = this.genreService.GetGenres() });
            }
        }

        public void Delete(Guid id)
        {
            this.movieService.DeleteMovie(id);
        }
    }
}