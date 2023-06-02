using CarConfigurator.Entity;
using CarConfigurator.Types;

namespace CarConfigurator.Builders;

public class CarExteriorBuilder : CarConfigurator
{
    private Car _car;

    public CarExteriorBuilder(Car car) : base(car)
    {
        _car = car;
        _car.Exterior ??= new Exterior();
    }

    public CarExteriorBuilder WithColor(CarColor color)
    {
        _car.Exterior.Color = color;
        return this;
    }

    public CarExteriorBuilder WithTyresType(TyresType tyres)
    {
        _car.Exterior.TyresType = tyres;
        return this;
    }
}