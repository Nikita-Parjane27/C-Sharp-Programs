using System;
namespace MergeArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = {10, 20, 30, 40, 50};
            int[] arr2 = {60, 70, 80, 90, 100};
            int[] mergedArr = new int[arr1.Length + arr2.Length];
            // Copy elements of arr1 to mergedArr
            for (int i = 0; i < arr1.Length; i++)
            {
                mergedArr[i] = arr1[i];
            }
            // Copy elements of arr2 to mergedArr
            for (int i = 0; i < arr2.Length; i++)
            {
                mergedArr[arr1.Length + i] = arr2[i];
            }
            Console.WriteLine("Merged array:");
            for (int i = 0; i < mergedArr.Length; i++)
            {
                Console.Write(mergedArr[i] + " ");
            }
        }
    }
}