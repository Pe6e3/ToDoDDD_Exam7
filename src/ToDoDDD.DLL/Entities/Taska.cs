using System.ComponentModel.DataAnnotations;

namespace ToDoDDD.DAL.Entities;

public class Taska : BaseEntity
{
    [Display(Name = "Название задачи")]
    public string TaskName { get; set; } = null!;

    [Display(Name = "Описание")]
    public string Desc { get; set; } = null!;

    [Display(Name = "Приоритет")]
    public Guid PrioritetGuid { get; set; }
    public virtual Prioritet? prioritet { get; set; }


    [Display(Name = "Статус")]
    public Guid StatusGuid { get; set; }
    public virtual Status? status { get; set; }

    [Display(Name = "Создана")]
    public DateTime CreateDate { get; set; }


}
