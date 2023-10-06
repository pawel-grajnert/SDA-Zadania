using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Mvc.Domain.Models.Base;

public class EntityBase
{
    [Key]
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public int CreatedByUserId { get; set; }

    public bool IsActive { get; set; }
}