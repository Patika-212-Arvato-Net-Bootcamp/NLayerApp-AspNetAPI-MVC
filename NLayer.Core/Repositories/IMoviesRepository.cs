using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IMoviesRepository:IGenericRepository<Movies>
    {
        Task<List<Movies>> GetMovieRateList(string rateFilter);
        Task<List<Movies>> GetMovieGenreList(int id);
        Task<Movies> GetMovieDetail(int id);
        Task<List<Movies>> ListMostViewedMovies();
        Task<List<Movies>> ListTopRatedMovies();
        Task<List<Movies>> GetMovieReleaseDateList(string releaseDate);

    }
}
