﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }

        //public ICollection<ActorMovie> ActorMovies { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
