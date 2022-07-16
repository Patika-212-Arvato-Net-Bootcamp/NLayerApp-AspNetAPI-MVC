using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class MoviesRepository : GenericRepository<Movies>, IMoviesRepository
    {
        public MoviesRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<Movies> GetMovieDetail(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Movies>> GetMovieGenreList(int id)
        {
            return await _context.Movies.Where(x => x.GenresId == id).ToListAsync();
           
        }

        public async Task<List<Movies>> GetMovieRateList(string rateFilter)
        {
            return await _context.Movies.Where(x => x.vote_average == rateFilter).ToListAsync();
        }

        public async Task<List<Movies>> GetMovieReleaseDateList(string releaseDate)
        {
            return await _context.Movies.Where(x => x.release_date == releaseDate).ToListAsync();
        }

        public async Task<List<Movies>> ListMostViewedMovies()
        {
            return await _context.Movies.OrderByDescending(x => x.popularity).ToListAsync();
        }
        public async Task<List<Movies>> ListTopRatedMovies()
        {
            return await _context.Movies.OrderByDescending(x => x.vote_count).ToListAsync();
        }
    }
}
