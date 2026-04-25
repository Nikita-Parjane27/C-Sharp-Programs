using System;
namespace ListCollectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a List to store integers
            System.Collections.Generic.List<int> numbers = new System.Collections.Generic.List<int>();

            // Add some integers to the List
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.Add(40);

            // Display the contents of the List
            Console.WriteLine("Contents of the List:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}