using CarConfigurator.Types;

namespace CarConfigurator.Entity;


public partial class Car
{
    public class CarPropulsionBuilder : CarConfigurator
    {
        private Car _car;

        public CarPropulsionBuilder(Car car) : base(car)
        {
            _car = car;
            _car.Propulsion ??= new Propulsion();
        }

        public CarPropulsionBuilder WithEngine(Engine engine)
        {
            _car.Propulsion.Engine = engine;
            return this;
        }

        public CarPropulsionBuilder WithTransmission(Transmission transmission)
        {
            _car.Propulsion.Transmission = transmission;
            return this;
        }

        public CarPropulsionBuilder WithPropulsionType(PropulsionType propulsionType)
        {
            _car.Propulsion.Type = propulsionType;
            return this;
        }
    }
}