using System.ComponentModel.DataAnnotations;

namespace ToDoDDD.DAL.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}
