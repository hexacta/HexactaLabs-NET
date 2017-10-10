using System;
using System.Collections.Generic;

namespace MoviesNetCore.Model
{
    public class Genre
    {
        public Genre()
        {
            this.MovieGenres = new List<MovieGenre>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<MovieGenre> MovieGenres { get; set; }
    }
}