using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoList.Domain.IRepositories.@base;
using ToDoList.Infrastructure.Context;

namespace ToDoList.Infrastructure.Repositories.@base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context;

        public Repository(AppDbContext contexto)
        {
             _context = contexto;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);

            return result.Entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
    }
}
