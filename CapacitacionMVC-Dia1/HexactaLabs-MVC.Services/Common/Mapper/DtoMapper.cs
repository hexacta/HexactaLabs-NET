using HexactaLabs_MVC.Business.Movies;
using HexactaLabs_MVC.Dtos.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HexactaLabs_MVC.Dtos.Genres;
using HexactaLabs_MVC.Business.Genres;

namespace HexactaLabs_MVC.Services.Common.Mapper
{
    public class DtoMapper
    {
        public DtoMapper() 
        {
            this.ConfigureMapper();
        }

        public TDestination For<TSource, TDestination>(TSource entity)
        {
            return AutoMapper.Mapper.Map<TSource, TDestination>(entity);
        }

        private void ConfigureMapper()
        {
            AutoMapper.Mapper.CreateMap<Movie, MovieDto>();
            AutoMapper.Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}
