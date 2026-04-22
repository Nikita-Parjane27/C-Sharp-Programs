using System;
namespace CommonElementArray
{
    class Program
    {
        //common elements in two arrays
        static void Main(string[] args)
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 4, 5, 6, 7, 8 };

            int[] commonElements = FindCommonElements(array1, array2);

            Console.WriteLine("Common elements:");
            foreach (int element in commonElements)
            {
                Console.WriteLine(element);
            }
        }

        static int[] FindCommonElements(int[] arr1, int[] arr2)
        {
            System.Collections.Generic.List<int> commonList = new System.Collections.Generic.List<int>();

            foreach (int num in arr1)
            {
                if (Array.Exists(arr2, element => element == num))
                {
                    commonList.Add(num);
                }
            }

            return commonList.ToArray();
        }
    }
}