using System;
namespace DictionaryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Dictionary to store key-value pairs
            System.Collections.Generic.Dictionary<string, int> dictionary = new System.Collections.Generic.Dictionary<string, int>();

            // Add some key-value pairs to the Dictionary
            dictionary.Add("One", 1);
            dictionary.Add("Two", 2);
            dictionary.Add("Three", 3);
            dictionary.Add("Four", 4);

            // Display the contents of the Dictionary
            Console.WriteLine("Contents of the Dictionary:");
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }
    }
}