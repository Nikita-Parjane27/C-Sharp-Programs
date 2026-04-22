using System;
namespace RecursionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            Console.WriteLine("Enter the number of times to repeat:");
            int times = int.Parse(Console.ReadLine());

            string result = RepeatString(input, times);
            Console.WriteLine(result);
        }

        static string RepeatString(string str, int count)
        {
            if (count <= 0)
                return "";
            return str + RepeatString(str, count - 1);
        }
    }
}