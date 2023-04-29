using ToDoDDD.DAL.Datas;
using ToDoDDD.DAL.Entities;

namespace ToDoDDD.BLL.Repositories;

public class StatusRepository : Repository<Status>
{
    private readonly AppDbContext _db;
    public StatusRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

}
