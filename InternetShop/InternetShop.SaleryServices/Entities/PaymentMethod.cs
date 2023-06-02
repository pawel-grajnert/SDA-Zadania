namespace InternetShop.SalaryServices.Entities;

public class PaymentMethod
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal ProvisionPercent { get; set; }

    //Another data needed to proceed payment (API address etc.)
}