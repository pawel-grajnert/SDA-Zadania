using Oponeo.Orders.Domain.Entity;

namespace Oponeo.Orders.BusinessLogic.Orders;

public class ProcessedOrderDto
{
    public Order Order { get; set; }
    public decimal NetTotal { get; set; }
}