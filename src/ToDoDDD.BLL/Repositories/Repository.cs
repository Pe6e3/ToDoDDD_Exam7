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
        return dbSet.ToList();
    }


    public T GetById(Guid id)
    {
        return dbSet.Find(id);
    }

    public void Update(T entity)
    {
        dbSet.Attach(entity);
        _db.Entry(entity).State = EntityState.Modified;
    }

    public void Save()
    {
        _db.SaveChanges();
    }

    public void Insert(T entity)
    {
        dbSet.Add(entity);
    }
}
