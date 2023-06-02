using InternetShop.SalaryServices.Entities;
using InternetShop.SalaryServices.Repository;
using InternetShop.SalaryServices.Service;
using InternetShop.SalaryServices.Types;

namespace InternetShop.SalaryServices;

internal class Program
{
    static void Main(string[] args)
    {
        var testProducts = TestDataContainer.Products;

        var testCartOne = new ShoppingCart() { Products = testProducts, PaymentMethod = PaymentMethods.BankOne };
        var testCartTwo = new ShoppingCart() { Products = testProducts, PaymentMethod = PaymentMethods.BankTwo };

        var paymentService = new PaymentService();

        Console.WriteLine("------------------------------------------------------------------");
        paymentService.ProceedPayment(testCartOne);
        Console.WriteLine("------------------------------------------------------------------");
        paymentService.ProceedPayment(testCartTwo);
        Console.WriteLine("------------------------------------------------------------------");
    }
}