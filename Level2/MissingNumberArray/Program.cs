using System;
namespace MissingNumberArray
{
    class Program
    {
        //find the missing number in an array of integers from 1 to n
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array (n):");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter {n - 1} numbers from 1 to {n}:");
            int[] numbers = new int[n - 1];
            for (int i = 0; i < n - 1; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int missingNumber = FindMissingNumber(numbers, n);
            Console.WriteLine($"The missing number is: {missingNumber}");
        }
        
    }
}