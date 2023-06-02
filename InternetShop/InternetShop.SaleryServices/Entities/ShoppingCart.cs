using InternetShop.SalaryServices.Types;

namespace InternetShop.SalaryServices.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public List<Product> Products { get; set; }
    public PaymentMethods PaymentMethod { get; set; }
    public decimal PaymentFee { get; set; }
    public decimal TotalAmount { get; set; }
}