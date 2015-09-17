using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HexactaLabs_MVC.Models
{
    public class FilterViewModel
    {
        [Display(Name = "Buscar")]
        public string Filter { get; set; }
    }

    public class MovieSearchViewModel : FilterViewModel
    {
        public int? GenreId { get; set; }
    }
}