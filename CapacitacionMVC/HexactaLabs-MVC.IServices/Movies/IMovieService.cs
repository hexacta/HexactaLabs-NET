using HexactaLabs_MVC.Dtos.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexactaLabs_MVC.IServices.Movies
{
    public interface IMovieService
    {
        MovieDto GetMovie(int id);
    }
}
