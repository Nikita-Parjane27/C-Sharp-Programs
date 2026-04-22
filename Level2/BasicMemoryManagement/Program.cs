using System;
namespace BasicMemoryManagement
{
    class Program
    {
        //
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            string result = ReverseString(input);
            Console.WriteLine(result);
        }

        static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}