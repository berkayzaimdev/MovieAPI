using Entities.Dtos.ActorDtos;
using Entities.Dtos.GenreDtos;
using Entities.Dtos.ReviewDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.MovieDtos
{
    public class GetMovieWithAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ReviewDto> Reviews { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
        public IEnumerable<ActorDto> Actors { get; set; }
    }
}
