using System;
namespace NamedArgument
{
    class Program
    {
        //79. Program to demonstrate named arguments 

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            Console.WriteLine("Enter the number of times to repeat:");
            int times = int.Parse(Console.ReadLine());

            // Using named arguments to call the method
            string result = RepeatString(str: input, count: times);
            Console.WriteLine(result);
        }

        static string RepeatString(string str, int count)
        {
            return string.Join(" ", Enumerable.Repeat(str, count));
        }

    }
}