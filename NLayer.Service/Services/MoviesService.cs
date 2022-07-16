using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.MoviesDtos;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class MoviesService : Service<Movies>, IMoviesService
    {
        IMoviesRepository _moviesRepository;
        IMapper _mapper;
        IUnitOfWork _unitOfWork;

        public MoviesService(IGenericRepository<Movies> repository, IUnitOfWork unitOfWork, IMapper mapper, IMoviesRepository moviesRepository) : base(repository, unitOfWork)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }



        public async Task<CustomResponseDto<NoContentDto>> AddMovie(MoviesAddDto movies)
        {
            var value = _mapper.Map<Movies>(movies);
            await _moviesRepository.AddAsync(value);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(200);


        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteMovie(int id)
        {
            var value = await _moviesRepository.GetByIdAsync(id);
            _moviesRepository.Remove(value);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(200);
        }

        public async Task<CustomResponseDto<MoviesDto>> GetMovieDetail(int id)
        {
            var value = await _moviesRepository.GetMovieDetail(id);
            var MoviesDtoValue = _mapper.Map<MoviesDto>(value);
            return CustomResponseDto<MoviesDto>.Success(200, MoviesDtoValue);
        }

        public async Task<CustomResponseDto<List<MoviesDto>>> GetMovieGenreList(int id)
        {
            var value = await _moviesRepository.GetMovieGenreList(id);
            var MoviesDtoValue = _mapper.Map<List<MoviesDto>>(value);
            return CustomResponseDto<List<MoviesDto>>.Success(200, MoviesDtoValue);
        }

        public async Task<CustomResponseDto<List<MoviesRateDto>>> GetMovieRateList(string rateFilter)
        {
            var moviesValue = await _moviesRepository.GetMovieRateList(rateFilter);
            var movRateDto = _mapper.Map<List<MoviesRateDto>>(moviesValue);
            return CustomResponseDto<List<MoviesRateDto>>.Success(200, movRateDto);

        }

        public async Task<CustomResponseDto<List<MoviesDto>>> GetMovieReleaseDateList(string releaseDate)
        {
            var value = await _moviesRepository.GetMovieReleaseDateList(releaseDate);
            var moviesValue = _mapper.Map<List<MoviesDto>>(value);
            return CustomResponseDto<List<MoviesDto>>.Success(200, moviesValue);
        }

        public async Task<CustomResponseDto<MoviesDto>> UpdateMovie(MoviesUpdateDtos moviesUpdateDtos)
        {
            var value = _mapper.Map<Movies>(moviesUpdateDtos);
            _moviesRepository.Update(value);
            await _unitOfWork.CommitAsync();
            var moviesDto = _mapper.Map<MoviesDto>(value);
            return CustomResponseDto<MoviesDto>.Success(200, moviesDto);
        }

        public async Task<CustomResponseDto<List<MoviesDto>>> ListMostViewedMovies()
        {
            var value = await _moviesRepository.ListMostViewedMovies();
            var moviesValue = _mapper.Map<List<MoviesDto>>(value);
            return CustomResponseDto<List<MoviesDto>>.Success(200, moviesValue);

        }

        public async Task<CustomResponseDto<List<MoviesDto>>> ListTopRatedMovies()
        {
            var value = await _moviesRepository.ListTopRatedMovies();
            var moviesValue = _mapper.Map<List<MoviesDto>>(value);
            return CustomResponseDto<List<MoviesDto>>.Success(200, moviesValue);

        }
    }
}
