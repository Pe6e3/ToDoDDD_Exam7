namespace ToDoDDD.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    IEnumerable<T> Get();
    T GetById(Guid id);
    void Delete(T entity);
    void Update(T entity);

}
