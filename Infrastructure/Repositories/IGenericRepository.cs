using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        ICollection<T> GetAll();
        IQueryable<T> GetAllAsQueryable();
        void Create(T item);
        void Update(T item);
        void Remove(int id);
    }
}
