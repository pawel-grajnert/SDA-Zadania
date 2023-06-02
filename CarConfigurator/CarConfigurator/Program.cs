using CarConfigurator.Entity;
using CarConfigurator.Types;

namespace CarConfigurator;

internal class Program
{
    static void Main(string[] args)
    {
        var car = Car
            .Create(CarModel.Civic, 2023)
            .HasExterior
                .WithColor(CarColor.ObsidianBlue)
                .WithTyresType(TyresType.Summer)
            .HasInterior
                .WithSteeringWheel(DrivingWheelType.Leather)
                .WithSits(SitsType.ExclusiveLeatherWhite)
            .HasPropulsion
                .WithEngine(Engine.Petrol20VTEC)
                .WithTransmission(Transmission.Manual)
                .WithPropulsionType(PropulsionType.FWD_TwoWheels)
            .Build();
    }
}