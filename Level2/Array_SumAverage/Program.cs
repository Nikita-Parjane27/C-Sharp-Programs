using System;
namespace Array_SumAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5];
            Console.WriteLine("Enter 5 integers:");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            double average = (double)sum / arr.Length;
            Console.WriteLine("The sum of the array elements is: " + sum);
            Console.WriteLine("The average of the array elements is: " + average);
        }
    }
}