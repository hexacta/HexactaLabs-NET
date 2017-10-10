using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesNetCore.Web.Models
{
    public class GenreViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<MovieViewModel> Movies { get; set; }

    }
}