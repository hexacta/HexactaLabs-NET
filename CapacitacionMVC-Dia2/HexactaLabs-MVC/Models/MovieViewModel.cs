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
        public MovieViewModel() 
        {
            this.Genres = new List<int>();
        }

        public int Id { get; set; } 
        
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
}