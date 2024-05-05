using Entities.Models;
using Infrastructure.EFCore;
using Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Concrete
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(Context context) : base(context)
        {
        }

        public Movie GetMovieByIdWithAll(int id) => GetAllAsQueryable()
            .Include(x => x.Genres)
            .Include(x => x.Actors)
            .Include(x => x.Reviews)
            .FirstOrDefault(x => x.Id == id);
    }
}
