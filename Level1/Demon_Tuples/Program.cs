using System;
namespace Demon_Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            //program to demonstrate tuples
            var Student = ("Nikita Parjane", 21, "Computer Science"); // creating a tuple
            Console.WriteLine("Student Name: " + Student.Item1); // accessing tuple elements
            Console.WriteLine("Student Age: " + Student.Item2);
            Console.WriteLine("Student Major: " + Student.Item3);

            //deconstructing a tuple
            var (name, age, major) = Student; // deconstructing the tuple
            Console.WriteLine("Deconstructed Student Name: " + name);
            Console.WriteLine("Deconstructed Student Age: " + age);
            Console.WriteLine("Deconstructed Student Major: " + major);
        }
    }
}