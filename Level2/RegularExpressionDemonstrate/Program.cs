using System;
namespace RegularExpressionDemonstrate
{
    class Program
    {
        //demonstrate regular expression
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            Console.WriteLine("Enter a regular expression pattern:");
            string pattern = Console.ReadLine();

            bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
            if (isMatch)
            {
                Console.WriteLine("The input string matches the regular expression pattern.");
            }
            else
            {
                Console.WriteLine("The input string does not match the regular expression pattern.");
            }
        }
    }
}