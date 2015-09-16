using HexactaLabs_MVC.Dtos.Movies;
using HexactaLabs_MVC.IServices.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HexactaLabs_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService movieService;

        public HomeController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}