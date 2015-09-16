using HexactaLabs_MVC.Dtos.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexactaLabs_MVC.IServices.Genres
{
    public interface IGenreService
    {
        IEnumerable<GenreDto> GetAll();

        IEnumerable<GenreDto> GetByName(string name);
    }
}
