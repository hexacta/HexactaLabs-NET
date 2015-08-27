Hexacta Labs: .NET MVC - Primera parte
======================================

#Actividades

####Ejercicio 1: Pantallas para Películas y Géneros:

#####1-	Crear el service con el método FindAll:
Dentro del proyecto Data agregar dos clases llamadas GenreService y MovieService. Cada servicio con un método GetAll retornando una lista de cada entidad:
```
public IEnumerable<Genre> GetAll()
{
    return this.moviesContext.Genres.AsQueryable();
}
```

#####2-	Crear ViewModels:
Dentro de la carpeta Models del proyecto CapacitacionMVC.Web, crear dos clases (MoviesIndexViewModel y GenresIndexViewModel):
```
public class MoviesIndexModel
{
    public IEnumerable<Movie> Movies { get; set; }

    [Display(Name = "Buscar")]
    public string SearchText { get; set; }

    public Guid? GenreId { get; set; }
}
```

```
public class GenresIndexModel
{
    public IEnumerable<Genre> Genres { get; set; }

    [Display(Name = "Buscar")]
    public string SearchText { get; set; }
}
```

#####3-	Controller: 
Dentro de la carpeta Controllers del proyecto CapacitacionMVC.Web, crear dos clases para los controladores de las pantallas (MoviesController y GenresController).
En el método de la acción Index de cada controlador agregar las llamadas de tal forma que la vista reciba la lista de view models:

```
var viewModel = new GenresViewModel();
viewModel.Genres = genreService.GetAll();

return View(viewModel);
```

#####4-	Crear cshtml:
Agregar en la vista Index (tipada con el viewModel correspondiente) de cada entidad una lista que muestre las distintos registros recuperados de la base:

```
<div class="list-group">
    @foreach (var genre in Model.Genres)
    {
        @genre.Name
    }
</div>
```

####Ejercicio 2: Completando el ejemplo anterior agreguemos la posibilidad de buscar por un nombre los géneros. Realizar lo mismo para las películas.
#####1-	Agregarle un parámetro a la acción Index llamado “filtro (string?)” (puede ser null) que reciba el valor ingresado por el usuario.
#####2-	Modificar el método GetAll de GenreService para que reciba el filtro correspondiente y realice la búsqueda de los géneros:

```
public List<Genre> GetAll(string searchText)
{
    var genres = this.moviesContext.Genres.AsQueryable();

    if (searchText != null)
    {
        genres = genres.Where(w => w.Name.ToLower().Contains(searchText.ToLower()));
    }

    return genres.ToList();
}
```

####Ejercicio 3: Completando el ejercicio anterior se pide generar un listado de películas por género. La misma debe aparecer cuando se hace click en un género. Debe tener un estilo diferente al de géneros (agregar un layout diferente en cada caso). 
#####1-	Modificar el Index de los géneros de tal forma que el nombre sea un link:

```
<div class="list-group">
    @foreach (var genre in Model.Genres)
    {
        @Html.ActionLink(genre.Name, "Index", "Movies", new { genreId = genre.Id }, new { @class = "list-group-item" })
    }
</div>
```

#####2-	Modificar la acción Index del controlador de películas para que reciba el id de un género.
#####3-	Modificar el método GetAll de MovieService para que realice un filtro por el id del género.
Ejercicio 4: Para finalizar el ejercicio agregar al mismo la posibilidad de ver los detalles de una película. Utilizar display templates para mostrar y formatear las diferentes secciones:
#####4-	Agregar nuevas propiedades a la clase Movie.
#####5-	Mostrar en la nueva vista el detalle de la película utilizando DisplayFor
#####6-	Modificar la vista Index de la carpeta Movie de forma tal que cada película muestre un link llamado “Detalle” que llame a la acción Details del controlador para mostrar al detalle de la misma (se pasa el Id como parámetro).
#####7-	Agregar a MovieService un nuevo método GetById que recupere una película a partir de su Id:

```
 public Movie GetById(Guid id)
{
    return this.moviesContext.Movies.FirstOrDefault(f => f.Id == id);
}
```

#####8-	Agregar una nueva acción en el controlador de películas llamada Details que reciba el Id de una película y muestre su detalle:

```
 public ActionResult Details(Guid id)
{
    var movie = this.movieService.GetById(id);

    return this.View(new MoviesDetailsModel { Movie = movie });
}
```

#####9-	Agregar una nueva vista en la carpeta Movies llamada Details (vista tipada con el modelo MoviesDetailsModel)




