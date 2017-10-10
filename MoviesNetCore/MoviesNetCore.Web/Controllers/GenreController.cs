using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoviesNetCore.Model;
using MoviesNetCore.Repository;
using MoviesNetCore.Web.Models;

namespace MoviesNetCore.Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository genreRepository;
        public GenreController(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public IActionResult Index()
        {
            var genres = this.genreRepository.List();

            var viewModelList = new List<GenreViewModel>();

            foreach (var genre in genres)
            {
                var viewModel = new GenreViewModel();

                viewModel.Id = genre.Id;
                viewModel.Nombre = genre.Name;

                viewModelList.Add(viewModel);

            }

            return View(viewModelList);
        }
    }
}