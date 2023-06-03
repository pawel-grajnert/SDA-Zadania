using InternetShop.SalaryServices.Abstractions;
using InternetShop.SalaryServices.Entities;

namespace InternetShop.SalaryServices.Service.PaymentMethods;

public class BankTwo : BasePaymentMethod
{
    public override string Name => "BankOne";

    public BankTwo()
    {
        ProvisionPercent = 1.5M;
    }

    public override void ProceedPayment(ShoppingCart cart)
    {
        var cartProductsValue = cart.Products.Sum(p => p.TotalPrice);
        cart.PaymentFee = ProvisionPercent / 100 * cartProductsValue;
        cart.TotalAmount = cartProductsValue + cart.PaymentFee;

        LogPaymentSummary(cart, cartProductsValue);
    }
}