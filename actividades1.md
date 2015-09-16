
https://github.com/hexacta/HexactaLabs-NET/tree/HexactaLabs-NET-2.0/CapacitacionMVC

####Ejercicio 1: Pantallas para Películas y Géneros:
El objetivo del ejercicio es retornar todos los objetos películas de la BD y listarlos en su vista correspondiente.

 1) Agregar en la interface IMovieService, el mensaje  IEnumerable<MovieDto> GetAll()
 2) Implementarlo en la clase MovieService 
 
   public IEnumerable<MovieDto> GetAll()
	{
		return movieRepository.GetAll().Select(x => Map(x));
	}

	private MovieDto Map(Movie movie) 
	{
		return new MovieDto()
		{
			Id = movie.Id,
			Name = movie.Name,
			ReleaseDate = movie.ReleaseDate,
			Plot = movie.Plot,
			CoverLink = movie.CoverLink,
			Runtime = movie.Runtime,
			GenresIds = movie.Genres.Select(x => x.Id).ToList()
		};
	}
	
 3) Crear La clase interface IGenreService, con el metodo IEnumerable<GenreDto> GetAll() y la clase GenreService con la implementacion correspondiente
 
	public class GenreService : IGenreService
    {
        private IRepository<Genre> genreRepository;

        public GenreService(IRepository<Genre> genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        
        public IEnumerable<Dtos.Genres.GenreDto> GetAll()
        {
            return genreRepository.GetAll().Select(x => Map(x));
        }

        private GenreDto Map(Genre genre) 
        {
            return new GenreDto()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
    }
	
 4) 	Crear controllers MoviesController
 
 public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        // GET: Movies
        public ActionResult Index()
        {
            @TempData["MoviesList"] = this.movieService.GetAll();
            return View();
        }
    }
	
 5) Crear controller GenresController

	public class GenresController : Controller
    {
        private readonly IGenreService genreService;

        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        // GET: Genres
        public ActionResult Index()
        {
            @TempData["GenreList"] = this.genreService.GetAll();
            return View();
        }
    }
	
 6) Crear Views para Movies y Genres, las mismas deben usar el layout prestablecido

---------------------------------------------------------------------
MOVIES:
---------------------------------------------------------------------
@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<section>

    <div class="list-group">
        <table>
            <thead>
                <tr>
                    <th>Pelicula</th>
                    <th>Portada</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var movie in @TempData["MovieList"] as IEnumerable<HexactaLabs_MVC.Dtos.Movies.MovieDto>)
                {
                    <tr>
                        <td>
                            @movie.Name
                        </td>
                        <td>
                            <img src="@movie.CoverLink" />  
                        </td>
                    </tr>
                }
            </tbody>
        </table>
    </div>
    
</section>

---------------------------------------------------------------
GENRES
---------------------------------------------------------------
@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}
<section>

    <div class="list-group">
        <table>
            <thead>
                <tr>
                    <th>Generos</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var genre in @TempData["GenreList"] as IEnumerable<HexactaLabs_MVC.Dtos.Genres.GenreDto>)
                {
                    <tr>
                        <td>
                            @genre.Name
                        </td>
                    </tr>
                }
            </tbody>
        </table>
    </div>

</section>

---------------------------------------------------------------

7) Agregar links a los puntos de menu, en _Layout.cshtml

	<li class="@(controller == "home" ? "active" : null)"><a href="@Url.Action("Index", "Home")"><span class="glyphicon glyphicon-home"></span></a></li>
	<li class="@(controller == "genres" ? "active" : null)"><a href="@Url.Action("Index", "Genres")">Géneros</a></li>
	<li class="@(controller == "movies" ? "active" : null)"><a href="@Url.Action("Index", "Movies")">Películas</a></li>


####Ejercicio 2: Completando el ejemplo anterior agreguemos la posibilidad de buscar por un nombre los géneros. Realizar lo mismo para las películas.


0) Modificar el servicio IMovieService y agregar  IEnumerable<MovieDto> GetByName(string name); 
1) Implementar el servicio MovieService

       public IEnumerable<MovieDto> GetByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                return movieRepository.Get(x => x.Name.ToLower().Contains(name.ToLower())).Select(x => Map(x));

            return GetAll();
        }

2) Agregamos un FilterViewModel en la carpeta Model

    public class FilterViewModel
    {
        [Display(Name = "Buscar")]
        public string Filter { get; set; }
    }

3) Modificamos el controller MoviesController, agregamos filtro y llamos al servicio que corresponde

	public ActionResult Index(string filter)
	{
		@TempData["MovieList"] = this.movieService.GetByName(filter);
		return View();
	}	


4) Modificamos el Index.cshtml de Movies, agregamos referencia al viewmodel, form y el input
	
	@model HexactaLabs_MVC.Models.FilterViewModel
	
	@using (Html.BeginForm("Index", "Movies"))
        {
            <div> 
                @Html.TextBoxFor(m => m.Filter)
                <input type="submit" value="Search" />
            </div>
        }

REPETIMOS EL PROCESO PARA GENRES
5) Modificar el servicio IGenderService y agregar  IEnumerable<GenreDto> GetByName(string name); 

6) Implementar el servicio GenderService

	public IEnumerable<GenreDto> GetByName(string name)
	{
		if (!string.IsNullOrWhiteSpace(name))
			return genreRepository.Get(x => x.Name.ToLower().Contains(name.ToLower())).Select(x => Map(x));

		return GetAll();
	}

7) Modificamos el controller GenresController, agregamos filtro y llamos al servicio que corresponde

 // GET: Genres
	public ActionResult Index(string filter)
	{
		@TempData["GenreList"] = this.genreService.GetByName(filter);
		return View();
	}

8) Modificamos el Index.cshtml de Genres, agregamos el form y el input

	@model HexactaLabs_MVC.Models.FilterViewModel

	@using (Html.BeginForm("Index", "Movies"))
        {
            <div> 
                @Html.TextBoxFor(m => m.Filter)
                <input type="submit" value="Search" />
            </div>
        }

		
		
####Ejercicio 3: Completando el ejercicio anterior se pide generar un listado de películas por género. 
Las mismas deben aparecer cuando se hace click en un género.
//Debe tener un estilo diferente al de géneros (agregar un layout diferente en cada caso).
 
1) 	Modificar el Index de los géneros de tal forma que el nombre sea un link:

```
<div class="list-group">
    @foreach (var genre in Model.Genres)
    {
        @Html.ActionLink(genre.Name, "Index", "Movies", new { genreId = genre.Id }, new {  })
    }
</div>

2) Para que el filtro siga funcionando tenemos que extender el viewmodel, entonces creamos MovieSearchViewModel

	public class MovieSearchViewModel : FilterViewModel
    {
        public int? GenreId { get; set; }
    }

3) Modificamos el MoviesController

 // GET: Movies
        public ActionResult Index(int? genreId, string filter)
        {
            @TempData["MovieList"] = this.movieService.GetBy(filter, genreId);

            return View(new MovieSearchViewModel() { GenreId = genreId, Filter = filter });
        }
		
 4) Agregamos un hidden en Index de movies para mantener el genero seleccionado
 
      @Html.HiddenFor(m => m.GenreId)
	  
 5) Modificamos los servicios, MovieServices
 
		public IEnumerable<MovieDto> GetBy(string name, int? genreId)
        {
                return movieRepository.Get(x => 
                            ((name == null) ||  (name!=null && x.Name.ToLower().Contains(name.ToLower()))) &&
                            (!genreId.HasValue || genreId.HasValue && x.Genres.Any(g => g.Id == genreId.Value))
                    
                 ).Select(x => Map(x));
        }

		

####Ejercicio 4: Para finalizar el ejercicio agregar al mismo la posibilidad de ver los detalles de una película. 
Utilizar display templates para mostrar y formatear las diferentes secciones:

1) Crear la vista Detail, bajo la carpeta Movies

@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}
@model HexactaLabs_MVC.Dtos.Movies.MovieDto

<section>
    <div>
        @Html.DisplayFor(m => m.Name)
    </div>
    <div>
        @Html.DisplayFor(m => m.Plot)
    </div>
    <div>
        @Html.DisplayFor(m => m.ReleaseDate)
    </div>
    <div>
        @Html.DisplayFor(m => m.Runtime)
    </div>
    <div>
        <img src="@Model.CoverLink" /> 
    </div>
 
</section>

2) Agregar el ActionLink en la vista  Index de Movies

 @Html.ActionLink(movie.Name, "Detail", "Movies", new { id = @movie.Id }, new { })
 
 3) Agregar action Detail al controlador, que reciba como parametro el id
 //Consumir el servicio que ya existe
 
         public ActionResult Detail(int id)
        {
            var movie = movieService.GetMovie(id);

            return View(movie);
        }

//ACLARAR DE QUE SE PUEDE CREAR LA CLASE EstimationViewModel, en lugar de usar como model el dto		