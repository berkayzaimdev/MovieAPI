using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<Actor> Actors { get; set; } = new List<Actor>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
