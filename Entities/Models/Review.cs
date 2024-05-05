using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
