using System;
namespace ClassandObjectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Car class
            Car myCar = new Car();

            // Set properties of the car
            myCar.Make = "Toyota";
            myCar.Model = "Corolla";
            myCar.Year = 2020;

            // Call a method to display car information
            myCar.DisplayInfo();
        }
    }

    // Define a Car class
    class Car
    {
        // Properties of the Car class
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        // Method to display car information
        public void DisplayInfo()
        {
            Console.WriteLine($"Car Information: {Year} {Make} {Model}");
        }
    }
}