using InternetShop.SalaryServices.Entities;
using InternetShop.SalaryServices.Types;

namespace InternetShop.SalaryServices.Factories;

public class PaymentMethodFactory
{
    private const decimal BankTwoProvision = 1.5M;
    private const decimal BankOneProvisionBelow50 = 2M;
    private const decimal BankOneProvisionAbove50 = 1M;
    private const decimal BankOneProvisionThreshold = 50M;
    
    public PaymentMethod Create(PaymentMethods paymentMethod, decimal paymentAmount)
    {
        switch (paymentMethod)
        {
            case PaymentMethods.BankOne:
                return GetBankOnePaymentMethod(paymentAmount);

            case PaymentMethods.BankTwo:
                return new PaymentMethod() { Id = (int)paymentMethod, Name = "BankTwo", ProvisionPercent = BankTwoProvision };
                
            default:
                throw new ArgumentOutOfRangeException(nameof(paymentMethod), paymentMethod, null);
        }
    }

    private PaymentMethod GetBankOnePaymentMethod(decimal paymentAmount)
    {
        return new PaymentMethod()
        {
            Id = (int)PaymentMethods.BankOne, 
            ProvisionPercent = paymentAmount > BankOneProvisionThreshold ? BankOneProvisionAbove50 : BankOneProvisionBelow50,
            Name = "BankOne"
        };
    }
}