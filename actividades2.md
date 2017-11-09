Hexacta Labs: .NET MVC - Segunda parte
======================================

# Actividades

### Ejercicio 1: Permitir agregar una nueva película:

##### A - Crear una nueva acción Create en el controlador de películas:
```
public ActionResult Create()
{
   return this.View(new MoviesCreateModel() { ViewAction = ViewAction.Create, Movie = new MovieVM()});
}
```

##### B - Agregar una nueva vista "Create" con un formulario que permita cargar cada campo de una película. 
Deben utilizarse los helpers tipados de Razor  
 - FormBuilder  
 - LabelFor  
 - TextBoxFor  

#### C - El formulario debe ir por POST a una nueva acción Create del controlador:

```
[HttpPost]
public ActionResult Create(MovieVM movie)
{            
    if (this.ModelState.IsValid)
    {
    	var newMovieDb = new Movie();
    	newMovieDb.Name = movie.Name;
    	newMovieDb.ReleaseDate = movie.ReleaseDate;
    	newMovieDb.Plot = movie.Plot;
    	newMovieDb.CoverLink = movie.CoverLink;
    	newMovieDb.Runtime = movie.Runtime;
    	
    	this.movieService.AddMovie(newMovieDb);
    	
    	movie.AsViewModel(newMovieDb);
    }

    return this.View(new MoviesCreateModel() { ViewAction = ViewAction.Create, Movie = movie});
}
```



### Ejercicio 2: Agregar validaciones al alta de películas:

##### A- Campos requeridos: Name, ReleaseDate, Plot, CoverLink y Runtime.
##### B- ReleaseDate tiene que ser una fecha valida.
##### C- El rango valido de valores para Runtime es de 30 a 300. 
##### D- El campo Name solo permite 100 caracteres. 


### Ejercicio 3: Si la película se guardó exitosamente retornar a la grilla de películas y mostrar mensaje de éxito. 

##### A-El mensaje debe contener el nombre de la película que se creó:

```
this.TempData["successmessage"] = "Se ha agregado exitosamente la pelicula: " + movie.Name;
```

##### Bonus - Agregar otro botón “Save and New” que permitirá al usuario crear la película y seguir cargando otra película a continuación. En este caso, mostrar otro mensaje de éxito en este caso en la pantalla de creación de película. 


### Ejercicio 4: Agregar la funcionalidad de permitir editar una película. El usuario debería ser capaz de poder editar la película mediante haciendo click en un link botón “Editar” en la grilla de películas: 


##### A-	Agregar una nueva acción en el controlador de películas (reutilizar la vista de creación):
```
public ActionResult Edit(Guid id)
{
    var movie = this.movieService.GetMovieById(id);
    var vm = new MovieVM();
    vm.AsViewModel(movie);
    return this.View("Create", new MoviesCreateModel() { ViewAction = ViewAction.Edit, Movie = vm });
}
```


##### B- El formulario en este caso debe ir por POST a la acción Edit del controlador:
```
[HttpPost]
public ActionResult Edit(MovieVM movie)
{
    if (this.ModelState.IsValid)
    {
        var movieDb = this.movieService.GetMovieById(movie.Id);

        movieDb.Name = movie.Name;
        movieDb.ReleaseDate = movie.ReleaseDate;
        movieDb.Runtime = movie.Runtime;
        movieDb.CoverLink = movie.CoverLink;
        movieDb.Plot = movie.Plot;

        this.movieService.Update(movie);

        this.TempData["successmessage"] = "Se ha actualizado exitosamente la pelicula: " + movie.Name;

        return this.RedirectToAction("Index");
    }
    else
    {
    	return this.View("Create", new MoviesCreateModel() { ViewAction = ViewAction.Edit, Movie = movie });
    }
}
```
--
--

### Ejercicio 5: En la creación y edición de películas, incorporar la posibilidad de ingresar cuales son los géneros de la película. En la grilla de películas, por cada película mostrar cuáles son sus géneros.


##### A- Agregar un ListBox en la pantalla de creación de películas:
```
@Html.ListBox("selectedGenres", Model.Genres.Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString(), Selected = Model.Movie.Genres.Any(a => a.Id == s.Id) }), new { @class = "form-control", size = "8" })
```


##### B- Agregar un parámetro en la acción Crear/Editar que reciba la lista géneros seleccionados:
```
IEnumerable<Guid> selectedGenres
```


##### C- Agregar una nueva propiedad al viewModel que sea una lista de generos:
```
return this.View("Create", new MoviesCreateModel() { ViewAction = ViewAction.Edit, Movie = movie, Genres = this.genreService.GetGenres() });
```


##### D- Modificar las acciones para que se guarden las relaciones entre peliculas y generos:
```
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
```


--
--

### Ejercicio 6: En la grilla de películas, agregar un link “Delete” para borrar la película:

```
$.ajax({
    url: '@Url.Action("Delete")/' + movieId
}).done(function () {
    alert("The movie has been deleted");
    row.remove();
}).fail(function () { alert("error"); });
```

--
--

