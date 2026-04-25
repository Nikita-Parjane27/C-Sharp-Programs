using System;
namespace MultipleInheritance_InterfaceExample
{
    class Program
    {
        //program to demonstrate multiple inheritance using interfaces
        static void Main(string[] args)
        {
            // Create an instance of the Car class
            Car myCar = new Car("Toyota", "Corolla", 2020, 4);
            // Call a method to display car information
            myCar.DisplayInfo();

            // Create an instance of the Truck class
            Truck myTruck = new Truck("Ford", "F-150", 2021, 2);
            // Call a method to display truck information
            myTruck.DisplayInfo();  
            
        }
    }
}