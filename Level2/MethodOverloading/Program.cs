using System;
namespace MethodOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            Console.WriteLine("Enter the number of times to repeat:");
            int times = int.Parse(Console.ReadLine());

            string result1 = RepeatString(input, times);
            Console.WriteLine(result1);

            Console.WriteLine("Enter a character to repeat:");
            char charInput = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.WriteLine("Enter the number of times to repeat the character:");
            int charTimes = int.Parse(Console.ReadLine());

            string result2 = RepeatString(charInput, charTimes);
            Console.WriteLine(result2);
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

        static string RepeatString(char ch, int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += ch;
            }
            return result;
        }
    }
}