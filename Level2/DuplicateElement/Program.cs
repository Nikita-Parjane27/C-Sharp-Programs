using System;
namespace DuplicateElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            string result = RemoveDuplicateCharacters(input);
            Console.WriteLine(result);
        }

        static string RemoveDuplicateCharacters(string str)
        {
            string result = "";
            foreach (char c in str)
            {
                if (!result.Contains(c))
                {
                    result += c;
                }
            }
            return result;
        }
    }
}