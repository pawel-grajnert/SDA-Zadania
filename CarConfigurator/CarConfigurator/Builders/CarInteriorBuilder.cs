using CarConfigurator.Entity;
using CarConfigurator.Types;

namespace CarConfigurator.Builders;

public class CarInteriorBuilder : CarConfigurator
{
    private Car _car;

    public CarInteriorBuilder(Car car) : base(car)
    {
        _car = car;
        _car.Interior ??= new Interior();
    }

    public CarInteriorBuilder WithSteeringWheel(DrivingWheelType wheel)
    {
        _car.Interior.DrivingWheelType = wheel;
        return this;
    }

    public CarInteriorBuilder WithSits(SitsType sits)
    {
        _car.Interior.SitsType = sits;
        return this;
    }
}