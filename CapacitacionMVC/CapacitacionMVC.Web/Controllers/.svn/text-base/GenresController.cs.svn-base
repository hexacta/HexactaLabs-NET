namespace CapacitacionMVC.Web.Controllers
{
    using System.Web.Mvc;

    using CapacitacionMVC.Data;
    using CapacitacionMVC.Web.Models;

    public class GenresController : Controller
    {
        private readonly GenreService genreService;

        public GenresController()
        {
            this.genreService = new GenreService();
        }

        public ActionResult Index(string searchText = null)
        {
            return this.View(new GenresIndexModel { Genres = this.genreService.GetGenres(searchText), SearchText = searchText });
        }
    }
}