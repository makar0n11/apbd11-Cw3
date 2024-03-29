using cw3.Exceptions;
using cw3.Interfaces;

namespace cw3.Containers;

public class GasContainer : Container, IHazardNotifier
{
    private double Pressure { get; set; }
    
    public GasContainer(double cargoWeight,
        double height,
        double containerWeight,
        double depth,
        double maxCargoWeight,
        double pressure ) 
        : base(cargoWeight, height,containerWeight, depth, maxCargoWeight)
    {
        Pressure = pressure;
    }
    
    public override void Unload()
    {
        CargoWeight *= 0.05;
    }

    public override void Load(double cargoWeight)
    {
        base.Load(cargoWeight);
    }

    public void NotifyDangerSituation(string serialNumber)
    {
        Console.WriteLine($"$Niebezpieczna sytuacja w {serialNumber}");
    }

    public override string Info()
    {
        return "GAS " + base.Info() + $" ,pressure = {Pressure}";
    }
}