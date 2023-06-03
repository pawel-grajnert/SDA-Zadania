using InternetShop.SalaryServices.Entities;
using InternetShop.SalaryServices.Factories;

namespace InternetShop.SalaryServices.Service;

public class PaymentService
{
    public void ProceedPayment(ShoppingCart cart)
    {
        var paymentMethod = new PaymentMethodFactory().Create(cart.PaymentMethod);
        paymentMethod.ProceedPayment(cart);
    }
}