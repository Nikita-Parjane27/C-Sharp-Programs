using System;
namespace UserDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int age;
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter your age:");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Your name is " + name + " and your age is " + age + ".");
        }
    }
}