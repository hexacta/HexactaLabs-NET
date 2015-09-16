using HexactaLabs_MVC.Business.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexactaLabs_MVC.Business.Movies
{
    public class Movie
    {

        public Movie()
        {
            this.Genres = new List<Genre>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Plot { get; set; }

        public string CoverLink { get; set; }

        public int Runtime { get; set; }

        public virtual IList<Genre> Genres { get; set; }
    }
}
