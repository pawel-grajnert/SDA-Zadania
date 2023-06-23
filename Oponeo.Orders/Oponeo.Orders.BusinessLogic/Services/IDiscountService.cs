namespace Oponeo.Orders.BusinessLogic.Services;

public interface IDiscountService
{
    IEnumerable<string> GetAvailableCodes();
    bool UseCode(string code);
}