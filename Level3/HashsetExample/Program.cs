using System;
namespace HashsetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a HashSet to store unique integers
            System.Collections.Generic.HashSet<int> hashSet = new System.Collections.Generic.HashSet<int>();

            // Add some integers to the HashSet
            hashSet.Add(1);
            hashSet.Add(2);
            hashSet.Add(3);
            hashSet.Add(4);
            hashSet.Add(2); // This will not be added since it's a duplicate

            // Display the contents of the HashSet
            Console.WriteLine("Contents of the HashSet:");
            foreach (var item in hashSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}