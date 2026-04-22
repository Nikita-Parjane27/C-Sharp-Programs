using System;
namespace OptionalParameters
{
    class Program
    {
        //demonstates optional parameters
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            Console.WriteLine("Enter the number of times to repeat (optional, default is 1):");
            string timesInput = Console.ReadLine();
            int times = string.IsNullOrEmpty(timesInput) ? 1 : int.Parse(timesInput);

            string result = RepeatString(input, times);
            Console.WriteLine(result);
        }

        static string RepeatString(string str, int times = 1)
        {
            return string.Join(" ", Enumerable.Repeat(str, times));
        }

    }
}