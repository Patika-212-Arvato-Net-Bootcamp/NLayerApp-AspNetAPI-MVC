using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.Genres;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Genres> _service;

        public GenresController(IMapper mapper, IService<Genres> service)
        {

            _mapper = mapper;
            _service = service;
        }


  


        /// GET api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var genresValue = await _service.GetAllAsync();
           var genresDtoValue = _mapper.Map<List<GenresDto>>(genresValue);
    
            return CreateActionResult(CustomResponseDto<List<GenresDto>>.Success(200, genresDtoValue.ToList()));
        }



        [HttpPost]
        public async Task<IActionResult> Save(GenresPostDto GenresPostDto)
        {
            var genresValue = await _service.AddAsync(_mapper.Map<Genres>(GenresPostDto));
            var genresDtoValue = _mapper.Map<GenresDto>(genresValue);
            return CreateActionResult(CustomResponseDto<GenresDto>.Success(201, genresDtoValue));
        }


        [HttpPut]
        public async Task<IActionResult> Update(GenresPutDto genresputDto)
        {
            await _service.UpdateAsync(_mapper.Map<Genres>(genresputDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

       
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var genresValue = await _service.GetByIdAsync(id);




            await _service.RemoveAsync(genresValue);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
