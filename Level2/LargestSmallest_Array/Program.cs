using System;
namespace LargestSmallest_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {10,20,30,90,0};
            int largest = arr[0];
            int smallest = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > largest)
                {
                    largest = arr[i];
                }
                if (arr[i] < smallest)
                {
                    smallest = arr[i];
                }
            }
            Console.WriteLine("The largest element in the array is: " + largest);
            Console.WriteLine("The smallest element in the array is: " + smallest);
        }
    }
}