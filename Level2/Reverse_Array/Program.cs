using System;
namespace Reverse_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {10, 20, 30, 40, 50};
            Console.WriteLine("Original array:");
            for(int i=0; i<arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            // Reverse the array
            /*Array.Reverse(arr);
            Console.WriteLine("\nReversed array:");
            for(int i=0; i<arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }*/

            Console.WriteLine("\nReversed array:");
            for(int i=arr.Length-1; i>=0; i--)
            {
                Console.Write(arr[i] + " ");
            }

        }
    }
}