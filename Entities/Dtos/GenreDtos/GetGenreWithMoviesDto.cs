using Entities.Dtos.MovieDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.GenreDtos
{
    public class GetGenreWithMoviesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MovieDto> Movies { get; set; }
    }
}
