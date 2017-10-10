using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesNetCore.Web.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Nombre")]
        public string Name { get; set; }

        [Display(Name = "Lanzamiento")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Resumen")]
        public string Plot { get; set; }
        
        [MinLength(2)]
        [Display(Name = "Url Portada")]
        public string CoverLink { get; set; }

        [Range(30,300)]
        public int? Runtime { get; set; }

        public ICollection<string> Genres { get; set; }
    }
}