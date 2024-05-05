using Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Create(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            T item = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public T Get(int id) => _context.Set<T>().Find(id);

        public ICollection<T> GetAll() => _context.Set<T>().ToList();
        public IQueryable<T> GetAllAsQueryable() => _context.Set<T>().AsQueryable();

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();
        }
    }
}
