using ProductManagement.Mvc.Domain.Models.Base;

namespace ProductManagement.Mvc.Domain.Models;

public class Product : EntityBase
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}