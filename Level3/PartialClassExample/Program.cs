using System;
namespace PartialClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Car class
            Car myCar = new Car("Toyota", "Corolla", 2020, 4);
            // Call a method to display car information
            myCar.DisplayInfo();
        }
    }
}