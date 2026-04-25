using System;
using System.Collections.Generic;

class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}

class RoleBasedAuth
{
    static List<User> users = new List<User>
    {
        new User { Username = "admin", Password = "admin123", Role = "Admin" },
        new User { Username = "nikita", Password = "pass123", Role = "User" },
        new User { Username = "manager", Password = "mgr456", Role = "Manager" }
    };

    static void Main()
    {
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        var user = users.Find(u => u.Username == username && u.Password == password);

        if (user == null)
        {
            Console.WriteLine("Invalid credentials!");
            return;
        }

        Console.WriteLine($"\nWelcome, {user.Username}! Role: {user.Role}");

        switch (user.Role)
        {
            case "Admin":
                Console.WriteLine("Access: Full System Control");
                Console.WriteLine("- Manage Users");
                Console.WriteLine("- View Reports");
                Console.WriteLine("- System Settings");
                break;
            case "Manager":
                Console.WriteLine("Access: Manager Dashboard");
                Console.WriteLine("- View Reports");
                Console.WriteLine("- Manage Team");
                break;
            case "User":
                Console.WriteLine("Access: User Panel");
                Console.WriteLine("- View Profile");
                Console.WriteLine("- Submit Requests");
                break;
            default:
                Console.WriteLine("Unknown role.");
                break;
        }
    }
}