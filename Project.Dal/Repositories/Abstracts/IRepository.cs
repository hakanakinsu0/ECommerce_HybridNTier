using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    public interface IRepository<T> where T : class,IEntity
    {
        //Queries
        Task<List<T>> GetAllAsync();  
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> exp);

        //Command
        Task CreateAsync (T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T orijinalEntity, T newEntity);
    }
}
