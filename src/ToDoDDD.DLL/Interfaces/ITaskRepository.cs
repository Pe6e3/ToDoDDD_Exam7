using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoDDD.DAL.Entities;

namespace ToDoDDD.DAL.Interfaces;

public interface ITaskRepository :IRepository<Taska>, IDisposable
{

}
