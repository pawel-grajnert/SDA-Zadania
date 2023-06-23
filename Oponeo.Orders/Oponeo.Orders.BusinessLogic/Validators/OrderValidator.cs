using Oponeo.Orders.Domain.Entity;

namespace Oponeo.Orders.BusinessLogic.Validators;

public class OrderValidator : IOrderValidator
{
    public bool Validate(Order order)
    {
        if (order.OrderLines == null || !order.OrderLines.Any())
        {
            return false;
        }
        
        if (order.Customer == null)
        {
            return false;
        }

        return true;
    }
}