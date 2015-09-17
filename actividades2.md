Hexacta Labs: .NET MVC - Segunda parte
======================================

#Actividades

####Ejercicio 1: Permitir agregar una nueva película:

#####1-	Crear una nueva acción Create en el controlador de películas:
```
[HttpGet]
public ActionResult Create()
{
	this.ViewData.Model = new MovieViewModel();
	return this.View();
}
```

#####2-	Agregar una nueva vista Create con un formulario que permita cargar cada campo de una película. El formulario debe ir por POST a una nueva acción Create del controlado:

```
[HttpPost]
public ActionResult Create(MovieViewModel movie)
{
    if (this.ModelState.IsValid)
    {

        var movieDto = new MovieDto
        {
            Name = movie.Name,
            CoverLink = movie.CoverLink,
            Plot = movie.Plot,
            ReleaseDate = movie.ReleaseDate.Value,
            Runtime = movie.Runtime.Value
        };

        this.movieService.Create(movieDto);
    }

    return this.View(movie);
}
```

```
@model HexactaLabs_MVC.Models.MovieViewModel

@{
    ViewBag.Title = "Nueva Película";
}

<h2>Nueva</h2>


@using (Html.BeginForm("Create", "Movies", FormMethod.Post)) 
{
    <div>
        <hr />
        <div>
            @Html.LabelFor(model => model.Name)
            <div>
                @Html.EditorFor(model => model.Name)
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.ReleaseDate)
            <div>
                @Html.EditorFor(model => model.ReleaseDate)
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.Plot)
            <div>
                @Html.EditorFor(model => model.Plot)
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.CoverLink)
            <div>
                @Html.EditorFor(model => model.CoverLink)
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.Runtime)
            <div>
                @Html.EditorFor(model => model.Runtime)
            </div>
        </div>

        <div>
            <div>
                <input type="submit" value="Crear" />
            </div>
        </div>
    </div>
}

<div>
    @Html.ActionLink("Volver a la lista", "Index")
</div>

@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
}
```

#####3- Agregar un boton "Nueva" en la lista de peliculas

```
@Html.ActionLink("Nueva", "Create", "Movies")
```

--
--

####Ejercicio 2: Agregar validaciones al alta de películas:

#####1 Campos requeridos: ReleaseDate, Plot, CoverLink y Runtime.
#####2 El campo Plot solo permite 2000 caracteres. 
#####3 El rango valido de valores para Runtime es de 30 a 300. 
#####4 El LinkPoster Name solo permite 150 caracteres. 


```
public class MovieViewModel
{
    [Required]
    [StringLength(100)]
    [DisplayName("Nombre")]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Date, ErrorMessage = "Fecha inválida")]
    [DisplayName("Fecha")]
    public DateTime? ReleaseDate { get; set; }

    [Required]
    [StringLength(100)]
    [DisplayName("Trama")]
    public string Plot { get; set; }

    [Required]
    [StringLength(150)]
    [DisplayName("Link del Poster")]
    public string CoverLink { get; set; }

    [Required]
    [Range(30, 300)]
    [DisplayName("Duración")]
    public int? Runtime { get; set; }

    [DisplayName("Generos")]
    public IList<int> Genres { get; set; }
}
```

--
--

####Ejercicio 3: Si la película se guardó exitosamente retornar a la grilla de películas y mostrar mensaje de éxito. 


#####1-	El mensaje debe contener el nombre de la película que se creó:

```
this.TempData["successmessage"] = "Se ha agregado exitosamente la pelicula: " + movie.Name;
return RedirectToAction("Index");
```

--
--

####Ejercicio 4: Agregar mensajes de error debajo de cada campo cuando falla una validación.

```
@model HexactaLabs_MVC.Models.MovieViewModel

@{
    ViewBag.Title = "Nueva Película";
}

<h2>Nueva</h2>


@using (Html.BeginForm("Create", "Movies", FormMethod.Post))
{
    <div>
        <hr />
        <div>
            @Html.LabelFor(model => model.Name)
            <div>
                @Html.EditorFor(model => model.Name)
                @Html.ValidationMessageFor(model => model.Name, "")
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.ReleaseDate)
            <div>
                @Html.EditorFor(model => model.ReleaseDate)
                @Html.ValidationMessageFor(model => model.ReleaseDate, "")
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.Plot)
            <div>
                @Html.EditorFor(model => model.Plot)
                @Html.ValidationMessageFor(model => model.Plot, "")
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.CoverLink)
            <div>
                @Html.EditorFor(model => model.CoverLink)
                @Html.ValidationMessageFor(model => model.CoverLink,"")
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.Runtime)
            <div>
                @Html.EditorFor(model => model.Runtime)
                @Html.ValidationMessageFor(model => model.Runtime, "")
            </div>
        </div>

        <div>
            <div>
                <input type="submit" value="Crear" />
            </div>
        </div>
    </div>
}

<div>
    @Html.ActionLink("Volver a la lista", "Index")
</div>

@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
}

```

--
--

####Ejercicio 5: Traducir los mensajes de validaciones que se ven en ingles a castellano

```
    public class MovieViewModel
    {
        [Required(ErrorMessage="Campo Requerido")]
        [StringLength(100, ErrorMessage = "El nombre puede tener hasta {1} caractétes")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Date, ErrorMessage = "Fecha inválida")]
        [DisplayName("Fecha")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage="Campo Requerido")]
        [StringLength(100, ErrorMessage = "El nombre puede tener hasta {1} caractétes")]
        [DisplayName("Trama")]
        public string Plot { get; set; }

        [Required(ErrorMessage="Campo Requerido")]
        [StringLength(150, ErrorMessage = "El nombre puede tener hasta {1} caractétes")]
        [DisplayName("Link del Poster")]
        public string CoverLink { get; set; }

        [Required(ErrorMessage="Campo Requerido")]
        [Range(30, 300, ErrorMessage="Solo pueden ser valores entre {1} y {2}" )]
        [DisplayName("Duración")]
        public int? Runtime { get; set; }

        [DisplayName("Generos")]
        public IList<int> Genres { get; set; }
    }
```

--
--

####Ejercicio 6: Agregar la funcionalidad de permitir editar una película. El usuario debería ser capaz de poder editar la película haciendo click en un link “Editar” en la grilla de películas: 


#####1-	Agregar una nueva acción en el controlador de películas:

```
    public ActionResult Edit(int id)
    {
        var movie = movieService.GetMovie(id);

        var movieVM = new MovieViewModel
        {
            Id = movie.Id,
            Name = movie.Name,
            CoverLink = movie.CoverLink,
            Plot = movie.Plot,
            ReleaseDate = movie.ReleaseDate,
            Runtime = movie.Runtime
        };

        return View(movieVM);
    }

```


#####2- El formulario en este caso debe ir por POST a la acción Edit del controlado:
```
@model HexactaLabs_MVC.Models.MovieViewModel

@{
    ViewBag.Title = "Editar Película";
}

<h2>Editar</h2>

@using (Html.BeginForm("Edit","Movies",FormMethod.Post))
{
    <div>

         @Html.HiddenFor(model => model.Id)

        <div>
            @Html.LabelFor(model => model.Name)
            <div>
                @Html.EditorFor(model => model.Name)
                @Html.ValidationMessageFor(model => model.Name, "")
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.ReleaseDate)
            <div>
                @Html.EditorFor(model => model.ReleaseDate)
                @Html.ValidationMessageFor(model => model.ReleaseDate, "")
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.Plot)
            <div>
                @Html.EditorFor(model => model.Plot)
                @Html.ValidationMessageFor(model => model.Plot, "")
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.CoverLink)
            <div>
                @Html.EditorFor(model => model.CoverLink)
                @Html.ValidationMessageFor(model => model.CoverLink, "")
            </div>
        </div>

        <div>
            @Html.LabelFor(model => model.Runtime)
            <div>
                @Html.EditorFor(model => model.Runtime)
                @Html.ValidationMessageFor(model => model.Runtime, "")
            </div>
        </div>

        <div>
            <div>
                <input type="submit" value="Guardar" />
            </div>
        </div>
    </div>
}

<div>
    @Html.ActionLink("Volver a la lista", "Index")
</div>

```

```
[HttpPost]
public ActionResult Edit(MovieViewModel movie)
{
    if (this.ModelState.IsValid)
    {

        var movieDto = new MovieDto
        {
            Id = movie.Id,
            Name = movie.Name,
            CoverLink = movie.CoverLink,
            Plot = movie.Plot,
            ReleaseDate = movie.ReleaseDate.Value,
            Runtime = movie.Runtime.Value
        };

        this.movieService.Create(movieDto);
        this.TempData["successmessage"] = "Se ha editado exitosamente la pelicula: " + movie.Name;
        return RedirectToAction("Index");
    }

    return this.View(movie);
}
```

#####3- Agrega en la lista de peliculas una accion para "editar":
```
 <td>
	@Html.ActionLink("Editar", "Edit", "Movies", new { id = @movie.Id }, new { })
</td>
```



--
--



####Ejercicio 7: En la creación y edición de películas, incorporar la posibilidad de ingresar cuales son los géneros de la película.


#####1- Agregar un ListBox en la pantalla de creación de películas y otro igual en la edición:
```
 <div>
    <label>Géneros</label>
    <div>
        @Html.ListBox("selectedGenres", ((IEnumerable<HexactaLabs_MVC.Dtos.Genres.GenreDto>)ViewBag.Genres).Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString(), Selected = Model.Genres.Any(a => a == s.Id) }))
    </div>

</div>
```

#####2- Agregar un parámetro en la acción Crear/Editar que reciba la lista géneros seleccionados:
```
IEnumerable<Guid> selectedGenres
```


#####3- LLevar a la vista de creacion y de edicion la lista de generos:
```
this.ViewBag.Genres = this.genreService.GetAll();
```

Para eso va a ser necesario agregar el servicio de generos al controller:

```
private readonly IGenreService genreService;
```

```
public MoviesController(
    IMovieService movieService,
    IGenreService genreService)
{
    this.movieService = movieService;
    this.genreService = genreService;
}
```


--
--

####Ejercicio 8: En la grilla de películas, agregar un link “Borrar” para borrar la película:

```
 | @Html.ActionLink("Eliminar", "Delete", "Movies", new { id = @movie.Id }, new { })
```

```
public ActionResult Delete(int id)
{
    var movie = movieService.GetMovie(id);
            
    this.movieService.Delete(id);
            
    this.TempData["successmessage"] = "Se ha eliminado exitosamente la pelicula: " + movie.Name;

    return RedirectToAction("Index");
}
```

--
--


####Ejercicio 9: Aplicar Bootstrap al diseño de la cracion

```
@model HexactaLabs_MVC.Models.MovieViewModel

@{
    ViewBag.Title = "Nueva Película";
}

<h2>Nueva</h2>


@using (Html.BeginForm("Create", "Movies", FormMethod.Post))
{
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            @Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.ReleaseDate, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.ReleaseDate, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.ReleaseDate, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Plot, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Plot, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Plot, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.CoverLink, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.CoverLink, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.CoverLink, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Runtime, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Runtime, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Runtime, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <label class="control-label col-md-2">Géneros</label>
            <div class="col-md-10">
                @Html.ListBox("selectedGenres", ((IEnumerable<HexactaLabs_MVC.Dtos.Genres.GenreDto>)ViewBag.Genres).Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString(), Selected = Model.Genres.Any(a => a == s.Id) }))
            </div>

        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Crear" class="btn btn-default" />
            </div>
        </div>
    </div>
}

<div>
    @Html.ActionLink("Volver a la lista", "Index")
</div>

@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
}



```

####Ejercicio 10: detectar porque actualmente hay un bug de que no se guarda la duracion de las peliculas en la edición