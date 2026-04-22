using System;
namespace RemoveSpecialCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            string result = RemoveSpecialCharacters(input);
            Console.WriteLine("String after removing special characters:");
            Console.WriteLine(result);
        }

        static string RemoveSpecialCharacters(string str)
        {
            string result = "";
            foreach (char c in str)
            {
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                {
                    result += c;
                }
            }
            return result;
        }
    }
}