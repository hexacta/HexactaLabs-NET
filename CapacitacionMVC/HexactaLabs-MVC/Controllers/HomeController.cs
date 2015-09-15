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
            this.movieService.GetMovie(1); // se ejecuta una consulta a para que se dummy para que se cree la base de datos si no existe
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}