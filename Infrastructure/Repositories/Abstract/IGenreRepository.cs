using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Abstract
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Genre GetGenreByIdWithMovies(int id);
    }
}
