using AutoMapper;
using Entities.Dtos.MovieDtos;
using Entities.Dtos.ReviewDtos;
using Entities.Models;
using Infrastructure.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _reviewRepository.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _reviewRepository.Get(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateReviewDto createReviewDto)
        {
            var value = _mapper.Map<Review>(createReviewDto);
            _reviewRepository.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateReviewDto updateReviewDto)
        {
            var value = _mapper.Map<Review>(updateReviewDto);
            _reviewRepository.Update(value);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _reviewRepository.Remove(id);
            return NoContent();
        }

        [HttpGet("GetReviewsByMovieId/{id}")]
        public IActionResult GetReviewsByMovieId(int id)
        {
            var value = _mapper.Map<IEnumerable<ReviewDto>>(_reviewRepository.GetReviewsByMovieId(id));
            return Ok(value);
        }
    }
}
