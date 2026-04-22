using System;
namespace SplitString_Words
{
    class Program
    {
        //split string into words
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            string[] words = input.Split(' '); // Split the string into words using space as a delimiter

            Console.WriteLine("Words in the string:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
        
    }
}