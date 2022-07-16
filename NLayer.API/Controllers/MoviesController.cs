using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.MoviesDtos;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Service.Services;
using StackExchange.Redis;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IMoviesService _service;
        private readonly IRedisService _redisservice;
        private readonly IDatabase _db;

        List<string> movieList = new List<string>();

        public MoviesController(IMapper mapper, IMoviesService service,IRedisService redisService)
        {

            _mapper = mapper;
            _service = service;
            _redisservice = redisService;
            _redisservice.Connect();
             _db = _redisservice.GetDb(0);
            _db.StringSet("numbersOfShow", 0);
         
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetMovieDetail(int id)
        {
           

            _db.StringIncrementAsync(id.ToString(), 1).Wait();
            var value = _db.StringGet(id.ToString());
            return CreateActionResult(await _service.GetMovieDetail(id));

        }

        [Route("[action]/{genreId}")]
        [HttpGet]
        public async Task<IActionResult> GetMovieListGenre(int genreId)
        {
            return CreateActionResult(await _service.GetMovieGenreList(genreId));
        }

        [Route("[action]/{rateFilter}")]
        [HttpGet]
        public async Task<IActionResult> GetMovieListRate(string rateFilter)
        {
            return CreateActionResult(await _service.GetMovieRateList(rateFilter));
        }

        [Route("[action]/{releaseDate}")]
        [HttpGet]
        public async Task<IActionResult> GetMovieListDate(string releaseDate)
        {
            return CreateActionResult(await _service.GetMovieReleaseDateList(releaseDate));
        }


        [HttpPost]
        public async Task<IActionResult> AddMovie(MoviesAddDto moviesAddDto)
        {

            return CreateActionResult(await _service.AddMovie(moviesAddDto));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMovie(MoviesUpdateDtos moviesupdateDto)
        {

            await _service.UpdateAsync(_mapper.Map<Movies>(moviesupdateDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            return CreateActionResult(await _service.DeleteMovie(id));
        }



    }
}
