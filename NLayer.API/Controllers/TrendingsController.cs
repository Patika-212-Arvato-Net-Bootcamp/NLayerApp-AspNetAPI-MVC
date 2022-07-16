using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrendingsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IMoviesService _service;

        public TrendingsController(IMapper mapper, IMoviesService service)
        {

            _mapper = mapper;
            _service = service;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> ListMostViewedMovies()
        {
            return CreateActionResult(await _service.ListMostViewedMovies());

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListTopRatedMovies()
        {
            return CreateActionResult(await _service.ListTopRatedMovies());

        }


    }
}
