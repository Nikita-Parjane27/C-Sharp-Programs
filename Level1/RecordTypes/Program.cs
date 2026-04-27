using System;

namespace RecordTypesDemo
{
    // 1. Basic record
    record Student(string Name, int Age, string Grade);

    // 2. Record with methods
    record Employee(string Name, string Department, double Salary)
    {
        public double AnnualSalary => Salary * 12;

        public string GetInfo() =>
            $"Name: {Name} | Dept: {Department} | Monthly: {Salary:C} | Annual: {AnnualSalary:C}";
    }

    // 3. Record with method
    record Point(double X, double Y)
    {
        public double DistanceTo(Point other) =>
            Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
    }

    // 4. Record struct
    record struct Color(int R, int G, int B)
    {
        public string ToHex() => $"#{R:X2}{G:X2}{B:X2}";
    }

    // 5. Inheritance
    record Person(string Name, int Age);
    record StudentPerson(string Name, int Age, string Course) : Person(Name, Age);

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Basic Record ===");

            var s1 = new Student("Nikita", 20, "A");
            var s2 = new Student("Nikita", 20, "A");
            var s3 = new Student("Ashwini", 21, "B");

            Console.WriteLine(s1);
            Console.WriteLine($"s1 == s2: {s1 == s2}");
            Console.WriteLine($"s1 == s3: {s1 == s3}");

            Console.WriteLine("\n=== With Expression ===");

            var s4 = s1 with { Grade = "A+" };
            Console.WriteLine($"Original : {s1}");
            Console.WriteLine($"Modified : {s4}");

            Console.WriteLine("\n=== Record with Methods ===");

            var emp = new Employee("Nikita", "IT", 50000);
            Console.WriteLine(emp.GetInfo());

            Console.WriteLine("\n=== Record Deconstruction ===");

            var (name, dept, salary) = emp;
            Console.WriteLine($"Name: {name}, Dept: {dept}, Salary: {salary}");

            Console.WriteLine("\n=== Point Distance ===");

            var p1 = new Point(0, 0);
            var p2 = new Point(3, 4);
            Console.WriteLine($"Distance: {p1.DistanceTo(p2)}");

            Console.WriteLine("\n=== Record Struct ===");

            var red = new Color(255, 0, 0);
            var green = new Color(0, 255, 0);
            Console.WriteLine($"Red   hex: {red.ToHex()}");
            Console.WriteLine($"Green hex: {green.ToHex()}");

            Console.WriteLine("\n=== Inheritance with Records ===");

            var sp = new StudentPerson("Nikita", 20, "Computer Science");
            Console.WriteLine(sp);
        }
    }
}