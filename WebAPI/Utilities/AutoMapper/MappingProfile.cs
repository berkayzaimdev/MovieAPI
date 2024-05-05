using AutoMapper;
using Entities.Dtos.ActorDtos;
using Entities.Dtos.GenreDtos;
using Entities.Dtos.MovieDtos;
using Entities.Dtos.ReviewDtos;
using Entities.Models;

namespace WebAPI.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Movie mappings
            CreateMap<UpdateMovieDto, Movie>();
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<Movie, MovieDto>();
            CreateMap<Movie, GetMovieWithAllDto>();

            // Genre mappings
            CreateMap<UpdateGenreDto, Genre>();
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Genre, GetGenreWithMoviesDto>();

            // Actor mappings
            CreateMap<UpdateActorDto, Actor>();
            CreateMap<CreateActorDto, Actor>();
            CreateMap<Actor, ActorDto>();
            CreateMap<Actor, GetActorWithMoviesDto>();

            // Review mappings
            CreateMap<UpdateReviewDto, Review>();
            CreateMap<CreateReviewDto, Review>();
            CreateMap<Review, ReviewDto>();
        }
    }
}
