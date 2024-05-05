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
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(Context context) : base(context)
        {
        }

        public Genre GetGenreByIdWithMovies(int id) => GetAllAsQueryable()
            .Include(x => x.Movies)
            .FirstOrDefault(x => x.Id == id);
    }
}
