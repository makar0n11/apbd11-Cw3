using System.ComponentModel;
using cw3.Exceptions;
using IContainer = cw3.Interfaces.IContainer;

namespace cw3.Containers;

public class Container(
    double cargoWeight,
    double height,
    double containerWeight,
    double depth,
    string serialNumber,
    double maxCargoWeight)
    : IContainer
{
    public double CargoWeight { get; set; } = cargoWeight;
    public double Height { get; set; } = height;
    public double ContainerWeight { get; set; } = containerWeight;
    public double Depth { get; set; } = depth;
    public string SerialNumber { get; set; } = serialNumber;
    protected double MaxCargoWeight { get; set; } = maxCargoWeight;

    public virtual void Unload()
    {
        CargoWeight = 0;
    }

    public virtual void Load(double cargoWeight)
    {
        if (cargoWeight > MaxCargoWeight)
        {
            throw new OverfillException("zbyt duży ładunek");
        }
        else
        {
            CargoWeight = cargoWeight;
        }
    }
    
    protected string GenerateSerialNumber()
    {
        Random rand = new Random();
        int randomNumber = rand.Next(1, 1000);
        return $"KON-C-{randomNumber}";
    }
}