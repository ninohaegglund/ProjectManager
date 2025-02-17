using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Interfaces;

namespace ProjectManager.Business.Repositories;

public class BaseRepository<T>(DataContext context) : IBaseRepository<T> where T : class
{
    protected readonly DataContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public IEnumerable<T> GetAll() => _dbSet.ToList();

    public T? GetById(long id) => _dbSet.Find(id);

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(long id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
