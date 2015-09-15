using HexactaLabs_MVC.IServices.Movies;
using System.Web.Mvc;

namespace HexactaLabs_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService movieService;

        public HomeController(IMovieService movieService)
        {
            this.movieService = movieService;
            this.movieService.GetMovie(1);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}