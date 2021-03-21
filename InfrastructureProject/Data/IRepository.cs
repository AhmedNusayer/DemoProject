using EntityProject;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfrastructureProject.Data
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Delete(int id);        
        
        Task<T> Add(T entity);

        Task<T> Update(T entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
