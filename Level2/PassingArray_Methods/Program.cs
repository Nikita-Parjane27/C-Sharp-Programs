using System;
namespace PassingArray_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Original array: " + string.Join(", ", numbers));

            // Passing the array to a method to modify it
            ModifyArray(numbers);
            Console.WriteLine("Modified array: " + string.Join(", ", numbers));
        }

        static void ModifyArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += 10; // This will modify the original array passed by reference
            }
        }
    }
}