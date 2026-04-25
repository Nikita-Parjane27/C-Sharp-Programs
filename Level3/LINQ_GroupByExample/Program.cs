using System;
namespace LINQ_GroupByExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample data: an array of strings
            string[] words = { "apple", "banana", "cherry", "avocado", "blueberry", "grape" };

            // Use LINQ to group the words by their first letter
            var groupedWords = System.Linq.Enumerable.GroupBy(words, w => w[0]);

            // Display the results
            Console.WriteLine("Words grouped by their first letter:");
            foreach (var group in groupedWords)
            {
                Console.WriteLine($"Group '{group.Key}':");
                foreach (var word in group)
                {
                    Console.WriteLine($"  {word}");
                }
            } 
        }
    }
}