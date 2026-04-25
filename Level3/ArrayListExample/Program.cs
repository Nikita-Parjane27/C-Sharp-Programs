using System;
namespace ArrayListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an ArrayList to store different types of data
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();

            // Add various types of data to the ArrayList
            arrayList.Add(42); // Adding an integer
            arrayList.Add("Hello, World!"); // Adding a string
            arrayList.Add(3.14); // Adding a double
            arrayList.Add(true); // Adding a boolean

            // Display the contents of the ArrayList
            Console.WriteLine("Contents of the ArrayList:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
        }
    }
}