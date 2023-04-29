using ToDoDDD.DAL.Datas;
using Microsoft.EntityFrameworkCore;
using ToDoDDD.DAL.Interfaces;

namespace ToDoDDD.BLL.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _db;
    private readonly DbSet<T> dbSet;
    public Repository(AppDbContext db)
    {
        _db = db;
        dbSet = db.Set<T>();
    }

    public void Delete(T entity)
    {
        if (_db.Entry(entity).State == EntityState.Detached)
        {
            dbSet.Attach(entity);
        }
        dbSet.Remove(entity);
    }

    public IEnumerable<T> Get()
    {
        throw new NotImplementedException();
    }

    public T GetByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        dbSet.Attach(entity);
        _db.Entry(entity).State = EntityState.Modified;
    }
}
