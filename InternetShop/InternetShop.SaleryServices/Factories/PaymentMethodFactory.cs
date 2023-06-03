using InternetShop.SalaryServices.Abstractions;
using InternetShop.SalaryServices.Service.PaymentMethods;
using InternetShop.SalaryServices.Types;

namespace InternetShop.SalaryServices.Factories;

public class PaymentMethodFactory
{
    public BasePaymentMethod Create(PaymentMethods paymentMethod)
    {
        switch (paymentMethod)
        {
            case PaymentMethods.BankOne:
                return new BankOne();

            case PaymentMethods.BankTwo:
                return new BankTwo();
                
            default:
                throw new ArgumentOutOfRangeException(nameof(paymentMethod), paymentMethod, null);
        }
    }
}