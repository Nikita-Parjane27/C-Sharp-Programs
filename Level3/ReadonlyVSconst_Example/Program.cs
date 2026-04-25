using System;
 namespace ReadonlyVSconst_Example
{
    class Program
    {
        // Define a constant for the speed limit
        const int SpeedLimit = 60;

        // Define a readonly field for the car's make
        readonly string CarMake;

        // Constructor to initialize the readonly field
        public Program(string carMake)
        {
            CarMake = carMake;
        }

        static void Main(string[] args)
        {
            // Create an instance of the Program class with a specific car make
            Program myCar = new Program("Toyota");

            // Display the car make and speed limit
            Console.WriteLine($"Car Make: {myCar.CarMake}");
            Console.WriteLine($"Speed Limit: {SpeedLimit} mph");
        }
    }
}