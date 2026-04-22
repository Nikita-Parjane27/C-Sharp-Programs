using System;
namespace Student_Grade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the student's grade (0-100):");
            int grade = Convert.ToInt32(Console.ReadLine());

            if (grade >= 90)
            {
                Console.WriteLine("Grade: A");
            }
            else if (grade >= 80)
            {
                Console.WriteLine("Grade: B");
            }
            else if (grade >= 70)
            {
                Console.WriteLine("Grade: C");
            }
            else if (grade >= 60)
            {
                Console.WriteLine("Grade: D");
            }
            else
            {
                Console.WriteLine("Grade: F");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}