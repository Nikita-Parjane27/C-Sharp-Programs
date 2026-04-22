using System;
namespace SecondLargest
{
    class Program
    {
        //find second largest number in an array
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array:");
            int size = int.Parse(Console.ReadLine());

            int[] numbers = new int[size];
            Console.WriteLine("Enter the elements of the array:");
            for (int i = 0; i < size; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int secondLargest = FindSecondLargest(numbers);
            if (secondLargest != int.MinValue)
            {
                Console.WriteLine($"The second largest number is: {secondLargest}");
            }
            else
            {
                Console.WriteLine("There is no second largest number.");
            }
        }
    }
}