namespace Oponeo.Orders.Domain.Entity;

public class Product
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Quantity { get; set; }
    public decimal TotalPrice => UnitPrice * Quantity;
}