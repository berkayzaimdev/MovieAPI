using AutoMapper;
using Entities.Dtos.GenreDtos;
using Entities.Models;
using Infrastructure.Repositories.Abstract;
using Infrastructure.Repositories.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenresController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _mapper.Map<IEnumerable<GenreDto>>(_genreRepository.GetAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _mapper.Map<GenreDto>(_genreRepository.Get(id));
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateGenreDto createGenreDto)
        {
            var genre = _mapper.Map<Genre>(createGenreDto);
            _genreRepository.Create(genre);
            return CreatedAtAction(nameof(Get), new { id = genre.Id }, _mapper.Map<GenreDto>(genre));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateGenreDto updateGenreDto)
        {
            var value = _mapper.Map<Genre>(updateGenreDto);
            _genreRepository.Update(value);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _genreRepository.Remove(id);
            return NoContent();
        }

        [HttpGet("GetGenreByIdWithMovies/{id}")]
        public IActionResult GetGenreByIdWithMovies(int id)
        {
            var value = _mapper.Map<GetGenreWithMoviesDto>(_genreRepository.GetGenreByIdWithMovies(id));
            return Ok(value);
        }
    }
}