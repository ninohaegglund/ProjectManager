using System.Linq.Expressions;

namespace ProjectManager.Data.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T?> AddAsync(T entity);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetAsync(Expression<Func<T, bool>> expression);
    Task<bool> DeleteAsync(T entity);
    Task<bool> UpdateAsync(T entity);
}