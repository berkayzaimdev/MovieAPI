using Entities.Models;
using Infrastructure.EFCore;
using Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Concrete
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(Context context) : base(context)
        {
        }

        public IEnumerable<Review> GetReviewsByMovieId(int id) => GetAll().Where(x => x.MovieId == id);
    }
}
