using System;
using System.Collections.Generic;

namespace MoviesNetCore.Model
{
    public class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}