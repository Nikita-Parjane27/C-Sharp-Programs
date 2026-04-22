using System;
namespace Salary_Allowances
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your basic salary:");
            double basicSalary = Convert.ToDouble(Console.ReadLine());

            double hra = 0.2 * basicSalary; // House Rent Allowance
            double da = 0.1 * basicSalary;  // Dearness Allowance
            double grossSalary = basicSalary + hra + da;

            Console.WriteLine("Basic Salary: " + basicSalary);
            Console.WriteLine("House Rent Allowance (HRA): " + hra);
            Console.WriteLine("Dearness Allowance (DA): " + da);
            Console.WriteLine("Gross Salary: " + grossSalary);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
