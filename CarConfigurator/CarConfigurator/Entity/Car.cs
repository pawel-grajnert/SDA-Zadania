using CarConfigurator.Types;

namespace CarConfigurator.Entity;

public class Car
{
    public CarModel Model { get; set; }
    public int ProductionYear { get; set; }
    public Propulsion Propulsion { get; set; }
    public Exterior Exterior { get; set; }
    public Interior Interior { get; set; }

    public static Builders.CarConfigurator Create(CarModel model, int productionYear)
    {
        return new Builders.CarConfigurator(model, productionYear);
    }
}