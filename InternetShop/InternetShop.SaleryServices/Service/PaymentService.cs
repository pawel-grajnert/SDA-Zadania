using System.Text;
using InternetShop.SalaryServices.Entities;
using InternetShop.SalaryServices.Factories;

namespace InternetShop.SalaryServices.Service;

public class PaymentService
{
    public void ProceedPayment(ShoppingCart cart)
    {
        var cartProductsValue = cart.Products.Sum(p => p.TotalPrice);
        var paymentMethod = new PaymentMethodFactory().Create(cart.PaymentMethod, cartProductsValue);

        cart.PaymentFee = paymentMethod.ProvisionPercent / 100 * cartProductsValue;
        cart.TotalAmount = cartProductsValue + cart.PaymentFee;

        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"\n\nCart products value: {cartProductsValue} PLN");
        stringBuilder.AppendLine($"Selected Payment Method: {paymentMethod.Name}");
        stringBuilder.AppendLine($"Payment provision percent: {paymentMethod.ProvisionPercent}%");
        stringBuilder.AppendLine($"Payment provision amount: {cart.PaymentFee} PLN");
        stringBuilder.AppendLine($"Total cart value with payment amount: {cart.TotalAmount} PLN");
        stringBuilder.AppendLine($"Payment successfully proceeded!");

        Console.WriteLine(stringBuilder.ToString());
    }
}