using HexactaLabs_MVC.IServices.Genres;
using HexactaLabs_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HexactaLabs_MVC.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService genreService;

        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        // GET: Genres
        public ActionResult Index(string filter)
        {
            @TempData["GenreList"] = this.genreService.GetByName(filter);
            return View(new FilterViewModel() { Filter = filter });
        }
    }
}