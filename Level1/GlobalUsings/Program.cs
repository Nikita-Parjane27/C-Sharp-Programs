// No using statements needed!
// All usings are in GlobalUsings.cs

Console.WriteLine("=== Global Usings Demo ===");

var students = new List<Student>
{
    new(1, "Nikita",    20),
    new(2, "Ashwini",   21),
    new(3, "Shubhangi", 22)
};

Console.WriteLine("Students:");
students.ForEach(s => s.Display());

Console.WriteLine("\n=== Math Helper ===");
Console.WriteLine($"Circle Area (r=5): {MathHelper.CircleArea(5):F2}");
Console.WriteLine($"Factorial (5)    : {MathHelper.Factorial(5)}");

Console.WriteLine("\nPrimes up to 20:");
var primes = MathHelper.GetPrimes(20);
Console.WriteLine(string.Join(", ", primes));

Console.WriteLine("\n=== LINQ (no using needed) ===");
var adults = students.Where(s => s.Age >= 21).ToList();
Console.WriteLine("Adults:");
adults.ForEach(s => s.Display());

Console.WriteLine("\n=== StringBuilder (no using needed) ===");
var sb = new StringBuilder();
sb.AppendLine("Hello");
sb.AppendLine("World");
Console.WriteLine(sb.ToString());