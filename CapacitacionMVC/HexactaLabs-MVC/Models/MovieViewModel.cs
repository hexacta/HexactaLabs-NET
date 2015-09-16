using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HexactaLabs_MVC.Models
{
    public class MovieViewModel
    {
        [Required]
        [StringLength(100)]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Fecha")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
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
}