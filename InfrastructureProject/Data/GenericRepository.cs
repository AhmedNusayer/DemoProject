using EntityProject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfrastructureProject.Data
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<T>().Add(entity);
            }
            await _context.SaveChangesAsync();
            //_context.Set<T>().AddRange(entities);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<T>().Remove(entity);
            }
            await _context.SaveChangesAsync();
            //_context.Set<T>().RemoveRange(entities);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
