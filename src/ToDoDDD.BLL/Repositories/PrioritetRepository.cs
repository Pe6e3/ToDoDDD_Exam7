using ToDoDDD.DAL.Datas;
using ToDoDDD.DAL.Entities;

namespace ToDoDDD.BLL.Repositories;

public class PrioritetRepository : Repository<Prioritet>
{
    private readonly AppDbContext _db;
    public PrioritetRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

}
