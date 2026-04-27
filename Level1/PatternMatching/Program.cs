// Pattern Matching in C#

// 1. Type Pattern
object[] items = { 42, "Hello", 3.14, true, null };

Console.WriteLine("=== Type Pattern ===");
foreach (var item in items)
{
    string result = item switch
    {
        int i    => $"Integer: {i}",
        string s => $"String: {s}",
        double d => $"Double: {d}",
        bool b   => $"Boolean: {b}",
        null     => "Null value",
        _        => "Unknown type"
    };
    Console.WriteLine(result);
}

// 2. Property Pattern
Console.WriteLine("\n=== Property Pattern ===");
var students = new[]
{
    new { Name = "Nikita",  Age = 20, Grade = "A" },
    new { Name = "Ashwini", Age = 17, Grade = "B" },
    new { Name = "Ravi",    Age = 22, Grade = "C" }
};

foreach (var s in students)
{
    string category = s switch
    {
        { Age: >= 18, Grade: "A" } => "Adult Top Scorer",
        { Age: >= 18 }             => "Adult Student",
        { Age: < 18 }              => "Minor Student",
        _                          => "Unknown"
    };
    Console.WriteLine($"{s.Name}: {category}");
}

// 3. Tuple Pattern
Console.WriteLine("\n=== Tuple Pattern ===");
string GetTrafficLight(string light, bool isRaining) =>
    (light, isRaining) switch
    {
        ("Red",   _)     => "Stop!",
        ("Green", true)  => "Go slowly - it's raining",
        ("Green", false) => "Go!",
        ("Yellow", _)    => "Slow down!",
        _                => "Invalid signal"
    };

Console.WriteLine(GetTrafficLight("Red",    false));
Console.WriteLine(GetTrafficLight("Green",  true));
Console.WriteLine(GetTrafficLight("Yellow", false));

// 4. Relational Pattern
Console.WriteLine("\n=== Relational Pattern ===");
string GetGrade(int marks) => marks switch
{
    >= 90 => "A+",
    >= 80 => "A",
    >= 70 => "B",
    >= 60 => "C",
    >= 50 => "D",
    _     => "F"
};

int[] marksList = { 95, 82, 71, 63, 55, 40 };
foreach (var m in marksList)
    Console.WriteLine($"Marks: {m} => Grade: {GetGrade(m)}");