namespace ToDoDDD.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    IEnumerable<T> Get();
    T GetByGuid(Guid guid);
    void Delete(T entity);
    void Update(T entity);

}
