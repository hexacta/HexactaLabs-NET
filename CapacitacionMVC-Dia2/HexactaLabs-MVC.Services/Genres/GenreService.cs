using HexactaLabs_MVC.Business.Common;
using HexactaLabs_MVC.Business.Genres;
using HexactaLabs_MVC.Dtos.Genres;
using HexactaLabs_MVC.IServices.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexactaLabs_MVC.Services.Genres
{
    public class GenreService : IGenreService
    {
        private IRepository<Genre> genreRepository;

        public GenreService(IRepository<Genre> genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        
        public IEnumerable<GenreDto> GetAll()
        {
            return genreRepository.GetAll().Select(x => Map(x));
        }

        public IEnumerable<GenreDto> GetByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                return genreRepository.Get(x => x.Name.ToLower().Contains(name.ToLower())).Select(x => Map(x));

            return GetAll();
        }

        private GenreDto Map(Genre genre) 
        {
            return new GenreDto()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
    }
}
