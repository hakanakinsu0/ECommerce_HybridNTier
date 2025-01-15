using Microsoft.EntityFrameworkCore;
using Project.Dal.ContextClasses;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Concretes
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        readonly MyContext _context;
        readonly DbSet<T> _dbSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }



        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T orijinalEntity, T newEntity)
        {
            _dbSet.Entry(orijinalEntity).CurrentValues.SetValues(newEntity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _dbSet.Where(exp);
        }
    }
}
