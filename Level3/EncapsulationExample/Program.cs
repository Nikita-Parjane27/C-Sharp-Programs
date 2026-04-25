using System;
namespace EncapsulationExample
{
    class Program
    {
        //program to demonstrate encapsulation in C#
        static void Main(string[] args)
        {
            // Create an instance of the Car class
            Car myCar = new Car("Toyota", "Corolla", 2020, 4);
            // Call a method to display car information
            myCar.DisplayInfo();
        }
    }
}