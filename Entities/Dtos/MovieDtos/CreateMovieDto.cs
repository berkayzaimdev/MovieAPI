using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.MovieDtos
{
    public class CreateMovieDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<int> ActorIds { get; set; } = new List<int>();
        public List<int> GenreIds { get; set; } = new List<int>();
    }
}
