using cw3.Containers;
using cw3.Exceptions;

namespace cw3;

public class ContainerShip
{
    public List<Container>? Containers { get; set; }
    public double Speed { get; set; }
    public int MaxCapacity { get; set; }
    public double MaxWeight { get; set; }

    public ContainerShip(List<Container> containers, double speed, int maxCapacity, double maxWeight)
    {
        Containers = containers;
        Speed = speed;
        MaxCapacity = maxCapacity;
        MaxWeight = maxWeight;
    }
    
    public ContainerShip(double speed, int maxCapacity, double maxWeight)
    {
        Containers = new List<Container>();
        Speed = speed;
        MaxCapacity = maxCapacity;
        MaxWeight = maxWeight;
    }

    public void LoadOnShip(Container container)
    {
        Containers.Add(container);
        if (!CheckWeight())
        {
            throw new ShipException("za duza waga");
        }

        if (Containers.Count > MaxCapacity)
        {
            throw new ShipException("za duzo kontenerow");
        }
    }
    public void LoadOnShip(Container container,string serialNumber)
    {
        this.UnLoad(serialNumber);
        Containers.Add(container);
        if (!CheckWeight())
        {
            throw new ShipException("za duza waga");
        }

        if (Containers.Count > MaxCapacity)
        {
            throw new ShipException("za duzo kontenerow");
        }
    }
    public void LoadOnShip(List<Container> containers)
    {
        Containers.AddRange(containers);
        if (!CheckWeight())
        {
            throw new ShipException("za duza waga");
        }

        if (Containers.Count > MaxCapacity)
        {
            throw new ShipException("za duzo kontenerow");
        }
    }

    public void UnLoad(string serialNumber)
    {
        Containers.Remove(Containers.Find(container => { return container.SerialNumber == serialNumber; }));

    }

    public bool CheckWeight()
    {
        double sum = 0;
        foreach (var container in Containers)
        {
            sum += container.ContainerWeight + container.CargoWeight;
        }

        if (sum * 0.001 > MaxWeight)
        {
            return false;
        }

        return true;
    }

    public void ShowSerialNumbers()
    {
        foreach (var container in Containers)
        {
            Console.WriteLine(container.SerialNumber);
        }
    }
    public string Info()
    {
        return $"speed = {Speed}, Max capacity = {MaxCapacity}, Max Weight = {MaxWeight}, containers count = {Containers.Count}";
    }
    
    
    
}