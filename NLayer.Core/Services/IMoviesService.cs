using NLayer.Core.DTOs;
using NLayer.Core.DTOs.MoviesDtos;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IMoviesService:IService<Movies>
    {
        Task<CustomResponseDto<List<MoviesRateDto>>> GetMovieRateList(string rateFilter);
        Task<CustomResponseDto<List<MoviesDto>>> GetMovieGenreList(int id);
        Task<CustomResponseDto<MoviesDto>> GetMovieDetail(int id);
        Task<CustomResponseDto<List<MoviesDto>>> GetMovieReleaseDateList(string releaseDate);
        Task<CustomResponseDto<NoContentDto>>AddMovie(MoviesAddDto movies);
        Task<CustomResponseDto<List<MoviesDto>>> ListMostViewedMovies();
        Task<CustomResponseDto<MoviesDto>> UpdateMovie(MoviesUpdateDtos moviesupdateDto);
        Task<CustomResponseDto<NoContentDto>> DeleteMovie(int id);
        Task<CustomResponseDto<List<MoviesDto>>> ListTopRatedMovies();
    }
}
