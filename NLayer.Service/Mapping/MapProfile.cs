using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs.Genres;
using NLayer.Core.DTOs.MoviesDtos;
using NLayer.Core.Models;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Genres, GenresDto>().ReverseMap();
            CreateMap<Genres, GenresPostDto>().ReverseMap();
            CreateMap<Genres, GenresPutDto>().ReverseMap();

            CreateMap<Movies, MoviesDto>().ReverseMap();
            CreateMap<Movies, MoviesRateDto>().ReverseMap();
            CreateMap<Movies, MoviesAddDto>().ReverseMap();
            CreateMap<Movies, MoviesUpdateDtos>().ReverseMap();
       
        }
    }
}
