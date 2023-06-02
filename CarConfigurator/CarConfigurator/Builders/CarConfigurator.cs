using CarConfigurator.Entity;
using CarConfigurator.Types;

namespace CarConfigurator.Builders;

public class CarConfigurator
{
    private Car _car { get; set; }

    public CarConfigurator(CarModel carModel, int productionYear)
    {
        _car = new Car() { Model = carModel, ProductionYear = productionYear };
    }

    protected CarConfigurator(Car car)
    {
        _car = car;
    }

    public CarInteriorBuilder HasInterior => new(_car);
    public CarExteriorBuilder HasExterior => new(_car);
    public CarPropulsionBuilder HasPropulsion => new(_car);
    
    public Car Build()
    {
        return _car;
    }
}