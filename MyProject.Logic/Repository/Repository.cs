using MyProject.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Logic.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dbset;
        public Repository(MyContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public void Create(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _dbset.Remove(entity);           
        }

        public List<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public void Update(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

        }
    }
}
