using System;
namespace LINQ_WhereSelectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample data: an array of integers
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Use LINQ to filter and project the data
            var evenSquares = System.Linq.Enumerable.Select(
                System.Linq.Enumerable.Where(numbers, n => n % 2 == 0), 
                n => n * n);

            // Display the results
            Console.WriteLine("Even squares:");
            foreach (var square in evenSquares)
            {
                Console.WriteLine(square);
            }
        }
    }
}