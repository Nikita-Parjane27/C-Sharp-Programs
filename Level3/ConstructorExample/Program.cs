using System;
namespace ConstructorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Car class using the constructor
            Car myCar = new Car("Toyota", "Corolla", 2020);

            // Call a method to display car information
            myCar.DisplayInfo();
        }
    }

    // Define a Car class with a constructor
    class Car
    {
        // Properties of the Car class
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        // Constructor to initialize the properties
        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        // Method to display car information
        public void DisplayInfo()
        {
            Console.WriteLine($"Car Information: {Year} {Make} {Model}");
        }
    }
}