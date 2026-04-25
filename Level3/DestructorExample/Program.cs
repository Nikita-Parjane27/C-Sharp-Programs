using System;
namespace DestructorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Car class
            Car myCar = new Car("Toyota", "Corolla", 2020);
            // Call a method to display car information
            myCar.DisplayInfo();
            // Set the myCar variable to null to trigger the destructor
            myCar = null;
            // Force garbage collection to see the destructor in action
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
    }
}