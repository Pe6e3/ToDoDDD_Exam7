using System.ComponentModel.DataAnnotations;

namespace ToDoDDD.DAL.Entities;

public class Taska : BaseEntity
{
    [Display(Name = "Название задачи")]
    public string TaskName { get; set; } = null!;

    [Display(Name = "Описание")]
    public string Desc { get; set; } = null!;

    public Guid PrioritetId { get; set; }
    [Display(Name = "Приоритет")]
    public virtual Prioritet? Prioritet { get; set; }


    public Guid StatusId { get; set; }
    [Display(Name = "Статус")]
    public virtual Status? Status { get; set; }

    [Display(Name = "Создана")]
    public DateTime CreateDate { get; set; }


}
