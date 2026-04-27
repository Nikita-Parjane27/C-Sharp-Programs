// Install: dotnet add package Microsoft.Extensions.DependencyInjection

using System;
using Microsoft.Extensions.DependencyInjection;

interface IGreetingService
{
    void Greet(string name);
}

class GreetingService : IGreetingService
{
    public void Greet(string name)
    {
        Console.WriteLine($"Hello, {name}! Welcome to Dependency Injection.");
    }
}

class StudentService
{
    private readonly IGreetingService _greetingService;

    public StudentService(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public void ProcessStudent(string name)
    {
        _greetingService.Greet(name);
        Console.WriteLine($"Processing student: {name}");
    }
}

class DIDemo
{
    static void Main()
    {
        // Register services
        var services = new ServiceCollection();
        services.AddSingleton<IGreetingService, GreetingService>();
        services.AddTransient<StudentService>();

        var provider = services.BuildServiceProvider();

        // Resolve and use
        var studentService = provider.GetService<StudentService>();
        studentService.ProcessStudent("Nikita");
    }
}