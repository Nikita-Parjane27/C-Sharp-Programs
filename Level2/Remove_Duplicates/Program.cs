using System;
namespace Remove_Duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {10, 20, 30, 20, 40, 10};
            Console.WriteLine("Original array:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            // Remove duplicates
            int[] uniqueArr = new int[arr.Length];
            int uniqueCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < uniqueCount; j++)
                {
                    if (arr[i] == uniqueArr[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    uniqueArr[uniqueCount] = arr[i];
                    uniqueCount++;
                }
            }
            Console.WriteLine("\nArray after removing duplicates:");
            for (int i = 0; i < uniqueCount; i++)
            {
                Console.Write(uniqueArr[i] + " ");
            }
        }
    }
}