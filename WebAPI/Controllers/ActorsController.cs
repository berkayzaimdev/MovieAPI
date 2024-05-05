using AutoMapper;
using Entities.Dtos.ActorDtos;
using Entities.Models;
using Infrastructure.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public ActorsController(IActorRepository actorRepository, IGenreRepository genreRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _mapper.Map<IEnumerable<ActorDto>>(_actorRepository.GetAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _mapper.Map<ActorDto>(_actorRepository.Get(id));
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateActorDto createActorDto)
        {
            var value = _mapper.Map<Actor>(createActorDto);
            _actorRepository.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateActorDto updateActorDto)
        {
            var value = _mapper.Map<Actor>(updateActorDto);
            _actorRepository.Update(value);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _actorRepository.Remove(id);
            return NoContent();
        }

        [HttpGet("GetActorWithMovies/{id}")]
        public IActionResult GetActorWithMovies(int id)
        {
            var value = _mapper.Map<GetActorWithMoviesDto>(_actorRepository.GetActorByIdWithMovies(id));
            return Ok(value);
        }
    }
}
