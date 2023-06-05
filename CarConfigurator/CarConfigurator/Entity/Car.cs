using CarConfigurator.Types;

namespace CarConfigurator.Entity;

public partial class Car
{
    protected Car()
    {
        
    }

    public CarModel Model { get; set; }
    public int ProductionYear { get; set; }
    public Propulsion Propulsion { get; set; }
    public Exterior Exterior { get; set; }
    public Interior Interior { get; set; }

    public static CarConfigurator Create(CarModel model, int productionYear)
    {
        return new CarConfigurator(model, productionYear);
    }
}