using System.Linq.Expressions;

namespace ToDoList.Domain.IRepositories.@base
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
