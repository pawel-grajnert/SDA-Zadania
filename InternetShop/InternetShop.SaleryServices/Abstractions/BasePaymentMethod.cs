using InternetShop.SalaryServices.Entities;
using System.Text;

namespace InternetShop.SalaryServices.Abstractions;

public abstract class BasePaymentMethod
{
    public virtual string Name { get; set; }
    public decimal ProvisionPercent { get; set; }

    public abstract void ProceedPayment(ShoppingCart cart);

    protected virtual void LogPaymentSummary(ShoppingCart cart, decimal cartProductsValue)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"\n\nCart products value: {cartProductsValue} PLN");
        stringBuilder.AppendLine($"Selected Payment Method: {Name}");
        stringBuilder.AppendLine($"Payment provision percent: {ProvisionPercent}%");
        stringBuilder.AppendLine($"Payment provision amount: {cart.PaymentFee} PLN");
        stringBuilder.AppendLine($"Total cart value with payment amount: {cart.TotalAmount} PLN");
        stringBuilder.AppendLine($"Payment successfully proceeded!");

        Console.WriteLine(stringBuilder.ToString());
    }
}