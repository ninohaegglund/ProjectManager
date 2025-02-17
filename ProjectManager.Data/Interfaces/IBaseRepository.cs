namespace ProjectManager.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(long id);
        IEnumerable<T> GetAll();
        T? GetById(long id);
        void Update(T entity);
    }
}