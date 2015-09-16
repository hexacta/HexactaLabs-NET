using HexactaLabs_MVC.Dtos.Genres;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexactaLabs_MVC.Dtos.Movies
{
    public class MovieDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Plot { get; set; }

        public string CoverLink { get; set; }

        public int Runtime { get; set; }

        public IList<int> GenresIds { get; set; }
    }
}
