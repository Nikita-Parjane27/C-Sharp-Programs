using System;
namespace SubString_Replace
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string oldSubstring = Console.ReadLine();
            string newSubstring = Console.ReadLine();

            string result = input.Replace(oldSubstring, newSubstring);
            Console.WriteLine(result);
        }
    }
}