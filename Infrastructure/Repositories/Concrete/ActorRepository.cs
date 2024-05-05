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
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(Context context) : base(context)
        {
        }

        public Actor GetActorByIdWithMovies(int id) => GetAllAsQueryable()
            .Include(x => x.Movies)
            .FirstOrDefault(x => x.Id == id);
    }
}
