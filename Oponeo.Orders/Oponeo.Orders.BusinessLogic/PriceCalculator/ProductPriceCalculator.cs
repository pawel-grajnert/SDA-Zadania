using Oponeo.Orders.Domain.Entity;

namespace Oponeo.Orders.BusinessLogic.PriceCalculator;

public class ProductPriceCalculator
{
    private const int FIRST_LEVEL_TOTAL_DISCOUNT = 400;
    private const int SECOND_LEVEL_TOTAL_DISCOUNT = 850;
    private const int QUANTITY_LEVLE_DISCOUNT = 10;

    private const decimal FIRST_PERCENTAGE_LEVEL = 0.1m;
    private const decimal SECOND_PERCENTAGE_LEVEL = 0.2m;

    public virtual decimal GetPrice(IEnumerable<Product> products)
    {
        if (products == null)
        {
            throw new ArgumentNullException(nameof(products));
        }

        if (!products.Any())
        {
            throw new ArgumentException(nameof(products));
        }

        decimal totalPrice = 0m;
        bool isDiscountApplied = false;

        foreach (var product in products)
        {
            if (product.Quantity >= QUANTITY_LEVLE_DISCOUNT)
            {
                totalPrice += product.TotalPrice - (product.TotalPrice * FIRST_PERCENTAGE_LEVEL);
                isDiscountApplied = true;
            }
            else
            {
                totalPrice += product.TotalPrice;
            }
        }

        if (!isDiscountApplied)
        {
            if (totalPrice > FIRST_LEVEL_TOTAL_DISCOUNT)
            {
                return totalPrice - (totalPrice * FIRST_PERCENTAGE_LEVEL);
            }
            
            if (totalPrice > SECOND_LEVEL_TOTAL_DISCOUNT)
            {
                return totalPrice - (totalPrice * SECOND_PERCENTAGE_LEVEL);
            }
        }

        return totalPrice;
    }
}