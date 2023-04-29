using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoDDD.DAL.Datas;
using ToDoDDD.DAL.Entities;

namespace ToDoDDD.BLL.Repositories;

public class TaskRepository : Repository<Taska>
{

    private readonly AppDbContext _db;
    public TaskRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public void ChangeStatus(Guid id, string statusName) 
    {
        Guid open = _db.Statuses.FirstOrDefault(s => s.StatusName == statusName).Id;
        Taska? myTask = GetById(id);
        myTask.StatusId = open;
        Update(myTask);
        Save();
    }

    public IEnumerable<Taska> GetIncluded()
    {
        return _db.Tasks
            .Include(p => p.Status)
            .Include(p => p.Prioritet)
            .ToList();
    }
    public Taska GetByIdIncluded(Guid id)
    {
        return _db.Tasks
            .Include(p => p.Prioritet)
            .Include(p => p.Status)
            .FirstOrDefault(t => t.Id == id);
    }




}
