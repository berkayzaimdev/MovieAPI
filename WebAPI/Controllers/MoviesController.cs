using AutoMapper;
using Entities.Dtos.MovieDtos;
using Entities.Models;
using Infrastructure.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository movieRepository, IActorRepository actorRepository, IGenreRepository genreRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var values = _mapper.Map<IEnumerable<MovieDto>>(_movieRepository.GetAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _mapper.Map<MovieDto>(_movieRepository.Get(id));
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMovieDto createMovieDto)
        {
            var value = _mapper.Map<Movie>(createMovieDto);

            foreach (var genreId in createMovieDto.GenreIds)
            {
                var genre = _genreRepository.Get(genreId);
                if (genre != null)
                {
                    value.Genres.Add(genre);
                }
            }

            foreach (var actorId in createMovieDto.ActorIds)
            {
                var genre = _actorRepository.Get(actorId);
                if (genre != null)
                {
                    value.Actors.Add(genre);
                }
            }

            _movieRepository.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, _mapper.Map<MovieDto>(value));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateMovieDto updateMovieDto)
        {
            var value = _mapper.Map<Movie>(updateMovieDto);
            _movieRepository.Update(value);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _movieRepository.Remove(id);
            return NoContent();
        }

        [HttpGet("GetMovieByIdWithAll/{id}")]
        public IActionResult GetMovieByIdWithAll(int id)
        {
            var value = _mapper.Map<GetMovieWithAllDto>(_movieRepository.GetMovieByIdWithAll(id));
            return Ok(value);
        }
    }
}
