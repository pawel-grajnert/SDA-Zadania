using Oponeo.Orders.BusinessLogic.PriceCalculator;
using Oponeo.Orders.BusinessLogic.Services;
using Oponeo.Orders.BusinessLogic.Validators;
using Oponeo.Orders.Domain.Entity;

namespace Oponeo.Orders.BusinessLogic.Orders;

public class OrderService
{
    private readonly ProductPriceCalculator _productPriceCalculator;
    private readonly IOrderValidator _orderValidator;
    private readonly IDiscountService _discountService;

    public OrderService(ProductPriceCalculator productPriceCalculator, IOrderValidator orderValidator, IDiscountService discountCodeService)
    {
        _productPriceCalculator = productPriceCalculator ?? throw new ArgumentNullException(nameof(productPriceCalculator));
        _orderValidator = orderValidator ?? throw new ArgumentNullException(nameof(orderValidator));
        _discountService = discountCodeService ?? throw new ArgumentNullException(nameof(discountCodeService));
    }

    public ProcessedOrderDto ProcessOrder(Order order)
    {
        if (!_orderValidator.Validate(order))
        {
            throw new ArgumentException($"Validation exception in {order.Guid}");
        }

        var netTotal = _productPriceCalculator.GetPrice(order.OrderLines);

        if (!string.IsNullOrWhiteSpace(order.DiscountCode))
        {
            var availableCodes = _discountService.GetAvailableCodes();

            if (availableCodes.Any(x => x == order.DiscountCode))
            {
                if (_discountService.UseCode(order.DiscountCode))
                {
                    netTotal -= 50;
                }
            }
        }

        return new ProcessedOrderDto
        {
            Order = order,
            NetTotal = netTotal,
        };
    }
}