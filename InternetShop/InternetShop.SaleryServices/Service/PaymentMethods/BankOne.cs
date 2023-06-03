using InternetShop.SalaryServices.Abstractions;
using InternetShop.SalaryServices.Entities;

namespace InternetShop.SalaryServices.Service.PaymentMethods;

public class BankOne : BasePaymentMethod
{
    private const decimal BankOneProvisionBelow50 = 2M;
    private const decimal BankOneProvisionAbove50 = 1M;
    private const decimal BankOneProvisionThreshold = 50M;
    public override string Name => "BankOne";

    public override void ProceedPayment(ShoppingCart cart)
    {
        var cartProductsValue = cart.Products.Sum(p => p.TotalPrice);
        ProvisionPercent = cartProductsValue > BankOneProvisionThreshold ? BankOneProvisionAbove50 : BankOneProvisionBelow50;

        cart.PaymentFee = ProvisionPercent / 100 * cartProductsValue;
        cart.TotalAmount = cartProductsValue + cart.PaymentFee;

        LogPaymentSummary(cart, cartProductsValue);
    }
}