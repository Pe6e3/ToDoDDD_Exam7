using Microsoft.EntityFrameworkCore;
using ToDoDDD.DAL.Entities;

namespace ToDoDDD.DAL.Datas;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Taska> Tasks { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Prioritet> Priorites { get; set; }

}
