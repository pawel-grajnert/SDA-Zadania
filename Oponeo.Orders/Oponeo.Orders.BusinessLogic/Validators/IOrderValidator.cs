using Oponeo.Orders.Domain.Entity;

namespace Oponeo.Orders.BusinessLogic.Validators;

public interface IOrderValidator
{
    bool Validate(Order order);
}