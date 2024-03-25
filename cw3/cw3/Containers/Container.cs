using System.ComponentModel;
using cw3.Exceptions;
using IContainer = cw3.Interfaces.IContainer;

namespace cw3.Containers;

public class Container: IContainer
{
    public Container(string serialNumber,double cargoWeight, double height, double containerWeight, double depth, double maxCargoWeight)
    {
        CargoWeight = cargoWeight;
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        MaxCargoWeight = maxCargoWeight;
        SerialNumber = serialNumber;
    }
    public Container(double cargoWeight, double height, double containerWeight, double depth, double maxCargoWeight)
    {
        CargoWeight = cargoWeight;
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        MaxCargoWeight = maxCargoWeight;
        SerialNumber = GenerateSerialNumber();
    }

    public double CargoWeight { get; set; }
    public double Height { get; set; } 
    public double ContainerWeight { get; set; }
    public double Depth { get; set; } 
    public string SerialNumber { get; set; }
    protected double MaxCargoWeight { get; set; }

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

    public virtual string Info()
    {
        return $"serial number = {SerialNumber}, cargo weight = {CargoWeight}, height = {Height}, container weight = {ContainerWeight}, depth = {Depth}, max cargo weight = {MaxCargoWeight}";
    }
}