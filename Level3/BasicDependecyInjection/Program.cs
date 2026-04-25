using System;
namespace BasicDependecyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Car class with a specific engine type
            IEngine engine = new PetrolEngine();
            Car myCar = new Car(engine);
            // Call a method to start the car
            myCar.Start();
        }
    }
}