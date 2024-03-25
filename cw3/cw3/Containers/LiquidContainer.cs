using cw3.Exceptions;
using cw3.Interfaces;

namespace cw3.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsDangerous{get; set;}

public LiquidContainer(
        double cargoWeight,
        double height,
        double containerWeight,
        double depth,
        double maxCargoWeight,
        bool isDangerous ) 
        : base(cargoWeight, height,containerWeight, depth, maxCargoWeight)
    {
        IsDangerous = isDangerous;
    }

    public override void Load(double cargoWeight)
    {
        if (IsDangerous)
        {
            if (cargoWeight > MaxCargoWeight*0.5)
            {
                throw new OverfillException("Możesz wypełnić kontener na płyn z niebezpiecznym ładunkiem do połowy");
            }
            else
            {
                CargoWeight = cargoWeight;
            }
        }
        else
        {
            if (cargoWeight > MaxCargoWeight*0.9)
            {
                throw new OverfillException("Możesz wypełnić kontener na płyn z bezpiecznym ładunkiem do 90%");
            }
            else
            {
                CargoWeight = cargoWeight;
            }
            
        }
        
    }
    
    public void NotifyDangerSituation(string serialNumber)
    {
        Console.WriteLine($"$Niebezpieczna sytuacja w {serialNumber}");
    }
    public override string Info()
    {
        return "LIQUID " + base.Info() + $" ,dangerous = {IsDangerous}";
    }
}

