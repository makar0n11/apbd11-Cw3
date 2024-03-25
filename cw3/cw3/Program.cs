
using cw3;
using cw3.Containers;
using cw3.enums;

class Program
{
    public static void Main(string[] args)
    {

        //1
        Console.WriteLine("1");
        Container container = new Container(0, 20, 100, 10, 10000);
        Container lContainer = new LiquidContainer(0, 20, 100, 10, 10000,true);
        Container gContainer = new GasContainer(0, 20, 100, 10, 10000, 25);
        Container cContainer = new RefrigeratedContainer(0, 30, 100, 10, 5000, Product.Bananas, 13.3);

        //2
        Console.WriteLine("2");
        container.Load(100);
        lContainer.Load(100);
        gContainer.Load(50);
        cContainer.Load(10);
        
        //3
        Console.WriteLine("3");
        ContainerShip ship = new ContainerShip(100, 25, 100);
        ship.LoadOnShip(container);
        ship.LoadOnShip(lContainer);
        ship.LoadOnShip(gContainer);
        ship.LoadOnShip(cContainer);
        ship.ShowSerialNumbers();
        
        //4
        Console.WriteLine("4");
        ship.LoadOnShip(new List<Container>{container,lContainer});
        ship.ShowSerialNumbers();
        
        //5
        Console.WriteLine("5");
        ship.UnLoad(container.SerialNumber);
        ship.ShowSerialNumbers();
        
        //6 
        Console.WriteLine("6");
        container.Unload();
        
        //7
        Console.WriteLine("7");
        ship.LoadOnShip(cContainer,container.SerialNumber);
        ship.ShowSerialNumbers();
        
        //8
        ContainerShip ship2 = new ContainerShip(10, 20, 1000);
        Console.WriteLine("8");
        ship.UnLoad(cContainer.SerialNumber);
        ship2.LoadOnShip(cContainer);
        //9
        Console.WriteLine("9");
        Console.WriteLine(container.Info());
        Console.WriteLine(gContainer.Info());
        Console.WriteLine(lContainer.Info());
        Console.WriteLine(cContainer.Info());
        
        //10
        Console.WriteLine("10");
        Console.WriteLine(ship.Info());
    }
}