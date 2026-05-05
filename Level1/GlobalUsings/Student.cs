// No using statements needed here!
// Because GlobalUsings.cs has them globally

class Student
{
    public int    Id   { get; set; }
    public string Name { get; set; }
    public int    Age  { get; set; }

    public Student(int id, string name, int age)
    {
        Id   = id;
        Name = name;
        Age  = age;
    }

    public void Display()
        => Console.WriteLine($"ID:{Id} | Name:{Name} | Age:{Age}");
}