using System;
namespace ArrayElement_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {10, 20, 30, 40, 50};
            Console.WriteLine("Enter an integer to search in the array:");
            int target = int.Parse(Console.ReadLine());
            bool found = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    found = true;
                    Console.WriteLine("Element found at index: " + i);
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Element not found in the array.");
            }
        }
    }
}