using System;
namespace Sort_ArrayElements
{
    class Program
    {
        static void Main(string[] args)
        {
             int[] arr = {90, 10, 30, 20, 0};
            Console.WriteLine("Original array:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            // Sort the array in ascending order
            Array.Sort(arr);
            Console.WriteLine("\nSorted array in ascending order:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            // Sort the array in descending order
            Array.Reverse(arr);
            Console.WriteLine("\nSorted array in descending order:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}