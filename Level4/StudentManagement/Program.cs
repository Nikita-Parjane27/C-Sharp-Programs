// ============================================================
//  Program #151 — Student Management System
//  Level 4 | C# Programming by Dr Kiran Khandarkar
// ============================================================
//
//  CONCEPTS COVERED:
//    - Class & Object
//    - Constructor
//    - Encapsulation (private fields + public properties)
//    - List<T> collection
//    - LINQ (Where, FirstOrDefault, Any)
//    - Custom exceptions
//    - Menu-driven console loop
//    - Input validation
// ============================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    // ─────────────────────────────────────────────────────────
    //  CUSTOM EXCEPTION
    //  Thrown when a student ID is not found in the system.
    // ─────────────────────────────────────────────────────────
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(int id)
            : base($"Student with ID {id} was not found.") { }
    }

    // ─────────────────────────────────────────────────────────
    //  STUDENT MODEL
    //  Encapsulates student data with validation in properties.
    // ─────────────────────────────────────────────────────────
    public class Student
    {
        // Private backing fields — data is hidden from outside
        private string _name;
        private int _age;
        private double _marks;

        // Auto-incremented ID — managed by the StudentManager
        public int Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                _name = value.Trim();
            }
        }

        public string Course { get; set; }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 1 || value > 100)
                    throw new ArgumentOutOfRangeException("Age must be between 1 and 100.");
                _age = value;
            }
        }

        public double Marks
        {
            get => _marks;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Marks must be between 0 and 100.");
                _marks = value;
            }
        }

        // Grade is computed — not stored, derived from Marks
        public string Grade => Marks switch
        {
            >= 90 => "A+",
            >= 80 => "A",
            >= 70 => "B",
            >= 60 => "C",
            >= 50 => "D",
            _      => "F"
        };

        // Constructor — requires all fields at creation time
        public Student(int id, string name, string course, int age, double marks)
        {
            Id     = id;
            Name   = name;
            Course = course;
            Age    = age;
            Marks  = marks;
        }

        // Clean display format for a single student
        public override string ToString()
        {
            return $"  ID     : {Id}\n" +
                   $"  Name   : {Name}\n" +
                   $"  Course : {Course}\n" +
                   $"  Age    : {Age}\n" +
                   $"  Marks  : {Marks:F1}%\n" +
                   $"  Grade  : {Grade}";
        }
    }

    // ─────────────────────────────────────────────────────────
    //  STUDENT MANAGER (Service Layer)
    //  Handles all business logic. UI layer calls this.
    //  This separation is the foundation of Clean Architecture.
    // ─────────────────────────────────────────────────────────
    public class StudentManager
    {
        private readonly List<Student> _students = new List<Student>();
        private int _nextId = 1; // Auto-increment counter

        // CREATE
        public Student AddStudent(string name, string course, int age, double marks)
        {
            var student = new Student(_nextId++, name, course, age, marks);
            _students.Add(student);
            return student;
        }

        // READ ALL
        public IReadOnlyList<Student> GetAllStudents()
        {
            return _students.AsReadOnly();
        }

        // READ ONE — throws if not found
        public Student GetById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id)
                ?? throw new StudentNotFoundException(id);
        }

        // SEARCH by name (case-insensitive, partial match)
        public List<Student> SearchByName(string keyword)
        {
            return _students
                .Where(s => s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // UPDATE
        public void UpdateStudent(int id, string name, string course, int age, double marks)
        {
            var student = GetById(id); // throws if not found
            student.Name   = name;
            student.Course = course;
            student.Age    = age;
            student.Marks  = marks;
        }

        // DELETE
        public void DeleteStudent(int id)
        {
            var student = GetById(id); // throws if not found
            _students.Remove(student);
        }

        // STATS — using LINQ aggregation
        public (double avg, double highest, double lowest) GetStats()
        {
            if (!_students.Any())
                return (0, 0, 0);

            return (
                _students.Average(s => s.Marks),
                _students.Max(s => s.Marks),
                _students.Min(s => s.Marks)
            );
        }

        public int TotalCount => _students.Count;
    }

    // ─────────────────────────────────────────────────────────
    //  CONSOLE UI (Presentation Layer)
    //  Only handles input/output. No business logic here.
    // ─────────────────────────────────────────────────────────
    public class ConsoleUI
    {
        private readonly StudentManager _manager = new StudentManager();

        public void Run()
        {
            SeedData(); // Add sample students so the app isn't empty

            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim();

                Console.WriteLine();
                try
                {
                    switch (choice)
                    {
                        case "1": AddStudent();     break;
                        case "2": ViewAll();        break;
                        case "3": SearchStudent();  break;
                        case "4": ViewById();       break;
                        case "5": UpdateStudent();  break;
                        case "6": DeleteStudent();  break;
                        case "7": ShowStats();      break;
                        case "0":
                            Console.WriteLine("  Goodbye!");
                            return;
                        default:
                            Warn("Invalid option. Please enter 0–7.");
                            break;
                    }
                }
                catch (StudentNotFoundException ex)
                {
                    Warn(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Warn("Validation error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Warn("Unexpected error: " + ex.Message);
                }

                Console.WriteLine();
                Console.Write("  Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        // ── MENU ────────────────────────────────────────────
        private void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ╔══════════════════════════════════════╗");
            Console.WriteLine($"  ║   STUDENT MANAGEMENT SYSTEM          ║");
            Console.WriteLine($"  ║   Total Students: {_manager.TotalCount,-18}║");
            Console.WriteLine("  ╠══════════════════════════════════════╣");
            Console.ResetColor();
            Console.WriteLine("  ║  1. Add Student                      ║");
            Console.WriteLine("  ║  2. View All Students                ║");
            Console.WriteLine("  ║  3. Search by Name                   ║");
            Console.WriteLine("  ║  4. View by ID                       ║");
            Console.WriteLine("  ║  5. Update Student                   ║");
            Console.WriteLine("  ║  6. Delete Student                   ║");
            Console.WriteLine("  ║  7. Class Statistics                 ║");
            Console.WriteLine("  ║  0. Exit                             ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ╚══════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("  Choose an option: ");
        }

        // ── CRUD OPERATIONS ─────────────────────────────────

        private void AddStudent()
        {
            Header("ADD STUDENT");
            string name   = Prompt("Name");
            string course = Prompt("Course");
            int    age    = ReadInt("Age");
            double marks  = ReadDouble("Marks (0–100)");

            var s = _manager.AddStudent(name, course, age, marks);
            Success($"Student added successfully with ID {s.Id}.");
        }

        private void ViewAll()
        {
            Header("ALL STUDENTS");
            var list = _manager.GetAllStudents();

            if (!list.Any())
            {
                Console.WriteLine("  No students found.");
                return;
            }

            // Table header
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {"ID",-5} {"Name",-20} {"Course",-15} {"Age",-5} {"Marks",-8} {"Grade",-5}");
            Console.WriteLine("  " + new string('─', 60));
            Console.ResetColor();

            foreach (var s in list)
            {
                Console.WriteLine($"  {s.Id,-5} {s.Name,-20} {s.Course,-15} {s.Age,-5} {s.Marks,-8:F1} {s.Grade,-5}");
            }
        }

        private void SearchStudent()
        {
            Header("SEARCH BY NAME");
            string keyword = Prompt("Enter name or keyword");
            var results = _manager.SearchByName(keyword);

            if (!results.Any())
            {
                Console.WriteLine($"  No students found matching '{keyword}'.");
                return;
            }

            Console.WriteLine($"  Found {results.Count} result(s):\n");
            foreach (var s in results)
            {
                Console.WriteLine(s);
                Console.WriteLine("  " + new string('─', 35));
            }
        }

        private void ViewById()
        {
            Header("VIEW STUDENT BY ID");
            int id = ReadInt("Student ID");
            var s = _manager.GetById(id);
            Console.WriteLine();
            Console.WriteLine(s);
        }

        private void UpdateStudent()
        {
            Header("UPDATE STUDENT");
            int id = ReadInt("Student ID to update");

            // Show current record first
            var current = _manager.GetById(id);
            Console.WriteLine("\n  Current record:");
            Console.WriteLine(current);
            Console.WriteLine();

            string name   = Prompt("New Name");
            string course = Prompt("New Course");
            int    age    = ReadInt("New Age");
            double marks  = ReadDouble("New Marks (0–100)");

            _manager.UpdateStudent(id, name, course, age, marks);
            Success("Student updated successfully.");
        }

        private void DeleteStudent()
        {
            Header("DELETE STUDENT");
            int id = ReadInt("Student ID to delete");

            var s = _manager.GetById(id);
            Console.WriteLine($"\n  You are about to delete: {s.Name}");
            Console.Write("  Are you sure? (yes/no): ");
            string confirm = Console.ReadLine()?.Trim().ToLower();

            if (confirm == "yes")
            {
                _manager.DeleteStudent(id);
                Success("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("  Delete cancelled.");
            }
        }

        private void ShowStats()
        {
            Header("CLASS STATISTICS");
            if (_manager.TotalCount == 0)
            {
                Console.WriteLine("  No data available.");
                return;
            }

            var (avg, highest, lowest) = _manager.GetStats();
            Console.WriteLine($"  Total Students : {_manager.TotalCount}");
            Console.WriteLine($"  Average Marks  : {avg:F2}%");
            Console.WriteLine($"  Highest Marks  : {highest:F1}%");
            Console.WriteLine($"  Lowest Marks   : {lowest:F1}%");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  Grade Distribution:");
            Console.ResetColor();

            var groups = _manager.GetAllStudents()
                .GroupBy(s => s.Grade)
                .OrderBy(g => g.Key);

            foreach (var g in groups)
                Console.WriteLine($"    Grade {g.Key} : {g.Count()} student(s)");
        }

        // ── HELPER METHODS ──────────────────────────────────

        private void SeedData()
        {
            _manager.AddStudent("Aisha Sharma",   "B.Tech CSE",  21, 88.5);
            _manager.AddStudent("Rohan Mehta",    "B.Tech IT",   22, 74.0);
            _manager.AddStudent("Priya Patil",    "BCA",         20, 92.0);
            _manager.AddStudent("Karan Desai",    "B.Tech CSE",  21, 55.5);
            _manager.AddStudent("Sneha Joshi",    "MCA",         23, 67.0);
        }

        private string Prompt(string label)
        {
            Console.Write($"  {label}: ");
            return Console.ReadLine()?.Trim() ?? "";
        }

        private int ReadInt(string label)
        {
            while (true)
            {
                Console.Write($"  {label}: ");
                if (int.TryParse(Console.ReadLine(), out int val))
                    return val;
                Warn("  Please enter a valid whole number.");
            }
        }

        private double ReadDouble(string label)
        {
            while (true)
            {
                Console.Write($"  {label}: ");
                if (double.TryParse(Console.ReadLine(), out double val))
                    return val;
                Warn("  Please enter a valid number.");
            }
        }

        private void Header(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ── {title} ──");
            Console.ResetColor();
        }

        private void Success(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✔ " + msg);
            Console.ResetColor();
        }

        private void Warn(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  ✘ " + msg);
            Console.ResetColor();
        }
    }

    // ─────────────────────────────────────────────────────────
    //  ENTRY POINT
    // ─────────────────────────────────────────────────────────
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var ui = new ConsoleUI();
            ui.Run();
        }
    }
}