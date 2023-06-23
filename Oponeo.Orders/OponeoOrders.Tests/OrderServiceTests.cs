using Moq;
using Oponeo.Orders.BusinessLogic.Orders;
using Oponeo.Orders.BusinessLogic.PriceCalculator;
using Oponeo.Orders.BusinessLogic.Services;
using Oponeo.Orders.BusinessLogic.Validators;
using Oponeo.Orders.Domain.Entity;

namespace OponeoOrders.Tests;

[TestClass]
public class OrderServiceTests
{
    private Mock<IOrderValidator> _validator = new();
    private Mock<ProductPriceCalculator> _priceCalculator = new();
    private Mock<IDiscountService> _discountService = new();

    [TestMethod]
    public void Method_ProcessOrder_Should_Throw_Exception_When_Order_Is_Not_Valid()
    {

        _validator.Setup(v => v.Validate(new())).Returns(false);

        var action = () => new OrderService(_priceCalculator.Object, _validator.Object, _discountService.Object).ProcessOrder(new());

        Assert.ThrowsException<ArgumentException>(action);
    }

    [TestMethod]
    public void Method_ProcessOrder_With_Delivered_Order_With_Discount_Code_Should_Call_Discount_Service_For_Code()
    {
        var order = new Order() { DiscountCode = "DUMMY1" };
        _validator.Setup(v => v.Validate(order)).Returns(true);
        _discountService.Setup(d => d.GetAvailableCodes()).Returns(new List<string>() { "DUMMY1", "DUMMY2" }).Verifiable();
        _priceCalculator.Setup(p => p.GetPrice(null)).Returns(0m);

        var result =
            new OrderService(_priceCalculator.Object, _validator.Object, _discountService.Object)
            .ProcessOrder(order);

        _discountService.Verify(d => d.GetAvailableCodes(), Times.Once);
    }

    [TestMethod]
    public void Method_ProcessOrder_With_Delivered_Order_With_Avaliable_Discount_Code_Should_Return_Processed_Order_With_Discounted_Price()
    {
        var order = new Order() { DiscountCode = "DUMMY1" };
        _validator.Setup(v => v.Validate(order)).Returns(true);
        _discountService.Setup(d => d.GetAvailableCodes()).Returns(new List<string>() { "DUMMY1", "DUMMY2" }).Verifiable();
        _discountService.Setup(d => d.UseCode(It.IsAny<string>())).Returns(true);
        _priceCalculator.Setup(p => p.GetPrice(null)).Returns(100m);

        var result =
            new OrderService(_priceCalculator.Object, _validator.Object, _discountService.Object)
                .ProcessOrder(order);

        Assert.AreEqual(50m, result.NetTotal);
    }

    [TestMethod]
    public void Method_ProcessOrder_With_Delivered_Order_With_Not_Avaliable_Discount_Code_Should_Return_Processed_Order_With_Not_Discounted_Price()
    {
        var order = new Order() { DiscountCode = "DUMMY3" };
        _validator.Setup(v => v.Validate(order)).Returns(true);
        _discountService.Setup(d => d.GetAvailableCodes()).Returns(new List<string>() { "DUMMY1", "DUMMY2" }).Verifiable();
        _priceCalculator.Setup(p => p.GetPrice(null)).Returns(100m);

        var result =
            new OrderService(_priceCalculator.Object, _validator.Object, _discountService.Object)
                .ProcessOrder(order);

        Assert.AreEqual(100m, result.NetTotal);
    }

    [TestMethod]
    public void Method_ProcessOrder_With_Delivered_Order_With_Avaliable_Discount_Code_Should_Call_Discount_Service_For_Use_This_Code_Only_Once()
    {
        var order = new Order() { DiscountCode = "DUMMY1" };
        _validator.Setup(v => v.Validate(order)).Returns(true);
        _discountService.Setup(d => d.GetAvailableCodes()).Returns(new List<string>() { "DUMMY1", "DUMMY2" }).Verifiable();
        _discountService.Setup(d => d.UseCode(It.IsAny<string>())).Returns(true);
        _priceCalculator.Setup(p => p.GetPrice(null)).Returns(0m);

        var result =
            new OrderService(_priceCalculator.Object, _validator.Object, _discountService.Object)
                .ProcessOrder(order);

        _discountService.Verify(d => d.UseCode(It.IsAny<string>()), Times.Exactly(1));
    }
}