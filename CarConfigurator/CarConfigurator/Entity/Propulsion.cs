using CarConfigurator.Types;

namespace CarConfigurator.Entity;

public class Propulsion
{
    public Engine Engine { get; set; }
    public Transmission Transmission { get; set; }
    public PropulsionType Type { get; set; }
}