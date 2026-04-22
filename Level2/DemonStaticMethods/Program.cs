using System;
namespace DemonStaticMethods
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
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += str;
            }
            return result;
        }
         
    }
}