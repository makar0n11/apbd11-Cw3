using System.Diagnostics;
using cw3.enums;

namespace cw3.Containers;

public class RefrigeratedContainer : Container
{
    private Product Product{get; set;}
    private double Temperature{get; set;}
    
    public RefrigeratedContainer(
        double cargoWeight,
        double height,
        double containerWeight,
        double depth,
        double maxCargoWeight,
        Product product,
        double temperature) 
        : base(cargoWeight, height,containerWeight, depth,  maxCargoWeight)
    {
        if (CheckTemperature(product, temperature))
        {
            Product = product;
            Temperature = temperature;
            
        }
        else
        {
            Console.WriteLine("zmien temperature dla tego produktu");
        }
        
        
    }

    private bool CheckTemperature(Product product, double temperature)
    {
        switch(Product)
        {
            case Product.Bananas:
            {
                if (temperature < 13.3) return false;
                return true;
            }
            case Product.Chocolate:
            {
                if (temperature < 18) return false;
                return true;
            }
            case Product.Fish:
            {
                if (temperature < 2) return false;
                return true;
            }
            case Product.Meat:
            {
                if (temperature < -15) return false;
                return true;
            }
            case Product.IceCream:
            {
                if (temperature < -18) return false;
                return true;
            }case Product.FrozenPizza:
            {
                if (temperature < -30) return false;
                return true;
            }case Product.Cheese:
            {
                if (temperature < 7.2) return false;
                return true;
            }case Product.Sausages:
            {
                if (temperature < 5) return false;
                return true;
            }
            case Product.Butter:
            {
                if (temperature < 20.5) return false;
                return true;
            }
            case Product.Eggs:
            {
                if (temperature < 19) return false;
                return true;
            }
            default: 
                Console.WriteLine("noSuchProduct");
                return false;
        }
    }
    public override string Info()
    {
        return "REFRIGERATED " + base.Info() + $" ,product = {Product} ,temperature = {Temperature}";
    }
    

}