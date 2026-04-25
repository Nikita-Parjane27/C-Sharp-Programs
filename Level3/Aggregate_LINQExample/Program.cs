using System;
namespace Aggregate_LINQExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an array of integers
            int[] numbers = { 1, 2, 3, 4, 5 };

            // Use LINQ to calculate the sum of the numbers
            int sum = System.Linq.Enumerable.Sum(numbers);
            Console.WriteLine("Sum: " + sum);

            // Use LINQ to calculate the average of the numbers
            double average = System.Linq.Enumerable.Average(numbers);
            Console.WriteLine("Average: " + average);

            // Use LINQ to find the maximum number
            int max = System.Linq.Enumerable.Max(numbers);
            Console.WriteLine("Max: " + max);

            // Use LINQ to find the minimum number
            int min = System.Linq.Enumerable.Min(numbers);
            Console.WriteLine("Min: " + min);
        }
    }
}