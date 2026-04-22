using System;
namespace StringInterplotation_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Nikita";
            int age = 20;
            // Using string interpolation to create a formatted string
            string message = $"Hello, my name is {name} and I am {age} years old.";
            Console.WriteLine(message);
        }
    }
}