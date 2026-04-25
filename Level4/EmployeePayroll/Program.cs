// ============================================================
//  Program #154 — Employee Payroll System
//  Level 4 | C# Programming by Dr Kiran Khandarkar
// ============================================================
//
//  CONCEPTS COVERED:
//    - Abstract class with abstract method (CalculateSalary)
//    - Inheritance: Manager, Developer, Intern extend Employee
//    - Interface: IPayable enforces GeneratePayslip()
//    - Enum: Department, EmployeeType
//    - decimal for all financial values
//    - readonly computed properties (Tax, NetSalary, etc.)
//    - LINQ: GroupBy, OrderBy, Sum, Average
//    - Method overriding with 'override' keyword
//    - Payslip formatted output
//    - Layered architecture (Model / Service / UI)
// ============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeePayrollSystem
{
    // ─────────────────────────────────────────────────────────
    //  ENUMS
    // ─────────────────────────────────────────────────────────
    public enum Department   { Engineering, HR, Finance, Marketing, Operations }
    public enum EmployeeType { Manager, Developer, Intern }

    // ─────────────────────────────────────────────────────────
    //  INTERFACE — every payable entity must implement this
    // ─────────────────────────────────────────────────────────
    public interface IPayable
    {
        decimal CalculateSalary();
        string  GeneratePayslip();
    }

    // ─────────────────────────────────────────────────────────
    //  ABSTRACT BASE — Employee
    //  Holds all common data. Salary breakdown is computed
    //  by subclasses via CalculateSalary().
    // ─────────────────────────────────────────────────────────
    public abstract class Employee : IPayable
    {
        private static int _idCounter = 100;

        public int          Id           { get; }
        public string       Name         { get; set; }
        public string       Email        { get; set; }
        public Department   Department   { get; set; }
        public EmployeeType Type         { get; }
        public DateTime     JoiningDate  { get; }
        public decimal      BasicSalary  { get; set; }

        // Allowances — can be overridden or set per subclass
        public virtual decimal HRA          => BasicSalary * 0.20m;  // House Rent
        public virtual decimal DA           => BasicSalary * 0.10m;  // Dearness
        public virtual decimal TA           => 1500m;                 // Travel (flat)

        // Deductions
        public virtual decimal PF           => BasicSalary * 0.12m;  // Provident Fund
        public virtual decimal Tax          => CalculateTax();

        // Computed totals
        public decimal GrossSalary  => BasicSalary + HRA + DA + TA;
        public decimal TotalDeduct  => PF + Tax;
        public decimal NetSalary    => GrossSalary - TotalDeduct;

        public int YearsOfService => (int)((DateTime.Today - JoiningDate).TotalDays / 365);

        protected Employee(string name, string email, Department dept,
                           EmployeeType type, DateTime joiningDate, decimal basicSalary)
        {
            Id          = ++_idCounter;
            Name        = name;
            Email       = email;
            Department  = dept;
            Type        = type;
            JoiningDate = joiningDate;
            BasicSalary = basicSalary;
        }

        // Progressive tax slab (simplified Indian IT slab)
        private decimal CalculateTax()
        {
            decimal annual = GrossSalary * 12;
            decimal tax    = 0;

            if      (annual > 1_500_000) tax = (annual - 1_500_000) * 0.30m + 150_000;
            else if (annual > 1_000_000) tax = (annual - 1_000_000) * 0.20m + 50_000;
            else if (annual > 500_000)   tax = (annual - 500_000)   * 0.20m;
            else if (annual > 250_000)   tax = (annual - 250_000)   * 0.05m;

            return Math.Round(tax / 12, 2);  // monthly tax
        }

        // Abstract — subclasses may add bonuses or commissions
        public abstract decimal CalculateSalary();

        // Payslip shared format — details filled by each subclass at the bottom
        public virtual string GeneratePayslip()
        {
            var sb = new StringBuilder();
            sb.AppendLine("  ┌─────────────────────────────────────────────┐");
            sb.AppendLine("  │           MONTHLY PAYSLIP                   │");
            sb.AppendLine("  ├─────────────────────────────────────────────┤");
            sb.AppendLine($"  │  Name       : {Name,-29} │");
            sb.AppendLine($"  │  ID         : {Id,-29} │");
            sb.AppendLine($"  │  Designation: {Type,-29} │");
            sb.AppendLine($"  │  Department : {Department,-29} │");
            sb.AppendLine($"  │  Joining    : {JoiningDate:dd MMM yyyy} ({YearsOfService} yr(s) service)   │");
            sb.AppendLine("  ├────────────────────┬────────────────────────┤");
            sb.AppendLine("  │  EARNINGS          │  DEDUCTIONS            │");
            sb.AppendLine("  ├────────────────────┼────────────────────────┤");
            sb.AppendLine($"  │  Basic   ₹{BasicSalary,8:F0}  │  PF       ₹{PF,8:F0}       │");
            sb.AppendLine($"  │  HRA     ₹{HRA,8:F0}  │  Tax      ₹{Tax,8:F0}       │");
            sb.AppendLine($"  │  DA      ₹{DA,8:F0}  │                        │");
            sb.AppendLine($"  │  TA      ₹{TA,8:F0}  │                        │");
            AppendExtraEarnings(sb);
            sb.AppendLine("  ├────────────────────┼────────────────────────┤");
            sb.AppendLine($"  │  Gross   ₹{GrossSalary,8:F0}  │  Total    ₹{TotalDeduct,8:F0}       │");
            sb.AppendLine("  ├────────────────────┴────────────────────────┤");
            sb.AppendLine($"  │  NET SALARY : ₹{CalculateSalary(),10:F2}                  │");
            sb.AppendLine("  └─────────────────────────────────────────────┘");
            return sb.ToString();
        }

        // Hook — subclasses append their bonus/commission lines here
        protected virtual void AppendExtraEarnings(StringBuilder sb) { }

        public override string ToString() =>
            $"  [{Id}] {Name,-20} {Type,-12} {Department,-14} ₹{CalculateSalary():F2}/mo";
    }

    // ─────────────────────────────────────────────────────────
    //  MANAGER
    //  Gets a management allowance + performance bonus
    // ─────────────────────────────────────────────────────────
    public class Manager : Employee
    {
        public decimal ManagementAllowance { get; set; } = 5000m;
        public decimal PerformanceBonus    { get; set; }

        public Manager(string name, string email, Department dept,
                       DateTime joining, decimal basic, decimal bonus = 0)
            : base(name, email, dept, EmployeeType.Manager, joining, basic)
        {
            PerformanceBonus = bonus;
        }

        public override decimal CalculateSalary() =>
            NetSalary + ManagementAllowance + PerformanceBonus;

        protected override void AppendExtraEarnings(StringBuilder sb)
        {
            sb.AppendLine($"  │  Mgmt    ₹{ManagementAllowance,8:F0}  │                        │");
            if (PerformanceBonus > 0)
                sb.AppendLine($"  │  Bonus   ₹{PerformanceBonus,8:F0}  │                        │");
        }
    }

    // ─────────────────────────────────────────────────────────
    //  DEVELOPER
    //  Gets a tech allowance; senior devs get an experience bonus
    // ─────────────────────────────────────────────────────────
    public class Developer : Employee
    {
        public decimal TechAllowance    { get; set; } = 3000m;
        public string  TechStack        { get; set; }

        // Extra ₹2000/month per year of service (max 5 years)
        public decimal ExperienceBonus =>
            Math.Min(YearsOfService, 5) * 2000m;

        public Developer(string name, string email, Department dept,
                         DateTime joining, decimal basic, string techStack = "C#/.NET")
            : base(name, email, dept, EmployeeType.Developer, joining, basic)
        {
            TechStack = techStack;
        }

        public override decimal CalculateSalary() =>
            NetSalary + TechAllowance + ExperienceBonus;

        protected override void AppendExtraEarnings(StringBuilder sb)
        {
            sb.AppendLine($"  │  Tech    ₹{TechAllowance,8:F0}  │                        │");
            if (ExperienceBonus > 0)
                sb.AppendLine($"  │  Exp Bon ₹{ExperienceBonus,8:F0}  │                        │");
        }
    }

    // ─────────────────────────────────────────────────────────
    //  INTERN
    //  Fixed stipend, no PF/tax, no allowances
    // ─────────────────────────────────────────────────────────
    public class Intern : Employee
    {
        public string CollegeName { get; set; }
        public int    DurationMonths { get; set; }

        // Interns have no allowances or deductions
        public override decimal HRA => 0;
        public override decimal DA  => 0;
        public override decimal TA  => 0;
        public override decimal PF  => 0;
        public override decimal Tax => 0;

        public Intern(string name, string email, Department dept,
                      DateTime joining, decimal stipend,
                      string college = "—", int durationMonths = 6)
            : base(name, email, dept, EmployeeType.Intern, joining, stipend)
        {
            CollegeName    = college;
            DurationMonths = durationMonths;
        }

        // Interns just get their stipend (BasicSalary)
        public override decimal CalculateSalary() => BasicSalary;

        public override string GeneratePayslip()
        {
            var sb = new StringBuilder();
            sb.AppendLine("  ┌─────────────────────────────────────────────┐");
            sb.AppendLine("  │           INTERN STIPEND SLIP                │");
            sb.AppendLine("  ├─────────────────────────────────────────────┤");
            sb.AppendLine($"  │  Name     : {Name,-31} │");
            sb.AppendLine($"  │  College  : {CollegeName,-31} │");
            sb.AppendLine($"  │  Dept     : {Department,-31} │");
            sb.AppendLine($"  │  Duration : {DurationMonths} months                         │");
            sb.AppendLine("  ├─────────────────────────────────────────────┤");
            sb.AppendLine($"  │  Monthly Stipend : ₹{BasicSalary:F2}                 │");
            sb.AppendLine("  └─────────────────────────────────────────────┘");
            return sb.ToString();
        }
    }

    // ─────────────────────────────────────────────────────────
    //  PAYROLL SERVICE
    // ─────────────────────────────────────────────────────────
    public class PayrollService
    {
        private readonly Dictionary<int, Employee> _employees = new();

        public Employee Add(Employee emp)
        {
            _employees[emp.Id] = emp;
            return emp;
        }

        public Employee Get(int id) =>
            _employees.TryGetValue(id, out var e) ? e
            : throw new Exception($"Employee ID {id} not found.");

        public IEnumerable<Employee> GetAll()       => _employees.Values;
        public IEnumerable<Employee> GetByDept(Department d) =>
            _employees.Values.Where(e => e.Department == d);

        public decimal TotalPayroll() =>
            _employees.Values.Sum(e => e.CalculateSalary());

        public IEnumerable<IGrouping<Department, Employee>> GroupByDepartment() =>
            _employees.Values.GroupBy(e => e.Department);

        public IEnumerable<IGrouping<EmployeeType, Employee>> GroupByType() =>
            _employees.Values.GroupBy(e => e.Type);

        public void UpdateBasicSalary(int id, decimal newBasic)
        {
            var emp = Get(id);
            if (newBasic <= 0) throw new ArgumentException("Salary must be positive.");
            emp.BasicSalary = newBasic;
        }

        public void RemoveEmployee(int id) => _employees.Remove(id);
    }

    // ─────────────────────────────────────────────────────────
    //  CONSOLE UI
    // ─────────────────────────────────────────────────────────
    public class ConsoleUI
    {
        private readonly PayrollService _payroll = new();

        public void Run()
        {
            SeedData();
            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim();
                Console.WriteLine();
                try
                {
                    switch (choice)
                    {
                        case "1":  AddEmployee();        break;
                        case "2":  ViewAllEmployees();   break;
                        case "3":  ViewPayslip();        break;
                        case "4":  SearchByDept();       break;
                        case "5":  UpdateSalary();       break;
                        case "6":  RemoveEmployee();     break;
                        case "7":  PayrollSummary();     break;
                        case "8":  DepartmentReport();   break;
                        case "0":  Console.WriteLine("  Goodbye!"); return;
                        default:   Warn("Invalid option."); break;
                    }
                }
                catch (Exception ex) { Warn(ex.Message); }

                Console.WriteLine();
                Console.Write("  Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ╔══════════════════════════════════════════╗");
            Console.WriteLine( "  ║        EMPLOYEE PAYROLL SYSTEM           ║");
            Console.WriteLine($"  ║  Employees: {_payroll.GetAll().Count(),-5}  Monthly Payroll: ₹{_payroll.TotalPayroll(),9:F0} ║");
            Console.WriteLine( "  ╠══════════════════════════════════════════╣");
            Console.ResetColor();
            Console.WriteLine( "  ║  1. Add Employee     2. View All         ║");
            Console.WriteLine( "  ║  3. View Payslip     4. Search by Dept   ║");
            Console.WriteLine( "  ║  5. Update Salary    6. Remove Employee  ║");
            Console.WriteLine( "  ║  7. Payroll Summary  8. Dept Report      ║");
            Console.WriteLine( "  ║  0. Exit                                  ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine( "  ╚══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("  Choose: ");
        }

        private void AddEmployee()
        {
            Header("ADD EMPLOYEE");
            Console.WriteLine("  Type: 1. Manager   2. Developer   3. Intern");
            Console.Write("  Choose: ");
            string type = Console.ReadLine()?.Trim();

            string     name    = Prompt("Full Name");
            string     email   = Prompt("Email");
            Department dept    = PickDepartment();
            DateTime   joining = ReadDate("Joining Date (dd/MM/yyyy)");
            decimal    basic   = ReadDecimal(type == "3" ? "Monthly Stipend (₹)" : "Basic Salary (₹)");

            Employee emp = type switch
            {
                "1" => new Manager(name, email, dept, joining, basic,
                            bonus: ReadDecimal("Performance Bonus (₹, 0 if none)")),
                "3" => new Intern(name, email, dept, joining, basic,
                            college: Prompt("College Name"),
                            durationMonths: ReadInt("Duration (months)")),
                _   => new Developer(name, email, dept, joining, basic,
                            techStack: Prompt("Tech Stack (e.g. C#/.NET)")),
            };

            _payroll.Add(emp);
            Success($"Employee added. ID: {emp.Id}  Net Salary: ₹{emp.CalculateSalary():F2}/mo");
        }

        private void ViewAllEmployees()
        {
            Header("ALL EMPLOYEES");
            var list = _payroll.GetAll().OrderBy(e => e.Department).ToList();
            if (!list.Any()) { Console.WriteLine("  No employees."); return; }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {"ID",-5} {"Name",-20} {"Type",-12} {"Dept",-14} {"Net Salary",12}");
            Console.WriteLine("  " + new string('─', 67));
            Console.ResetColor();

            foreach (var e in list)
                Console.WriteLine($"  {e.Id,-5} {e.Name,-20} {e.Type,-12} {e.Department,-14} ₹{e.CalculateSalary(),10:F2}");
        }

        private void ViewPayslip()
        {
            Header("VIEW PAYSLIP");
            int id  = ReadInt("Employee ID");
            var emp = _payroll.Get(id);
            Console.WriteLine();
            Console.WriteLine(emp.GeneratePayslip());
        }

        private void SearchByDept()
        {
            Header("SEARCH BY DEPARTMENT");
            Department dept = PickDepartment();
            var list = _payroll.GetByDept(dept).ToList();

            if (!list.Any()) { Console.WriteLine($"  No employees in {dept}."); return; }

            Console.WriteLine($"\n  {dept} Department — {list.Count} employee(s):\n");
            list.ForEach(e => Console.WriteLine(e));
        }

        private void UpdateSalary()
        {
            Header("UPDATE BASIC SALARY");
            int     id       = ReadInt("Employee ID");
            var     emp      = _payroll.Get(id);
            Console.WriteLine($"  Current Basic: ₹{emp.BasicSalary:F2}");
            decimal newBasic = ReadDecimal("New Basic Salary (₹)");
            _payroll.UpdateBasicSalary(id, newBasic);
            Success($"Salary updated. New net salary: ₹{emp.CalculateSalary():F2}/mo");
        }

        private void RemoveEmployee()
        {
            Header("REMOVE EMPLOYEE");
            int id  = ReadInt("Employee ID");
            var emp = _payroll.Get(id);
            Console.Write($"\n  Remove {emp.Name}? (yes/no): ");
            if (Console.ReadLine()?.Trim().ToLower() == "yes")
            { _payroll.RemoveEmployee(id); Success("Employee removed."); }
            else Console.WriteLine("  Cancelled.");
        }

        private void PayrollSummary()
        {
            Header("PAYROLL SUMMARY");
            var all = _payroll.GetAll().ToList();
            if (!all.Any()) { Console.WriteLine("  No data."); return; }

            decimal total   = all.Sum(e  => e.CalculateSalary());
            decimal avg     = all.Average(e => e.CalculateSalary());
            var     highest = all.MaxBy(e => e.CalculateSalary());
            var     lowest  = all.MinBy(e => e.CalculateSalary());

            Console.WriteLine($"  Total Employees  : {all.Count}");
            Console.WriteLine($"  Monthly Payroll  : ₹{total:F2}");
            Console.WriteLine($"  Annual Payroll   : ₹{total * 12:F2}");
            Console.WriteLine($"  Average Salary   : ₹{avg:F2}");
            Console.WriteLine($"  Highest Earner   : {highest?.Name} (₹{highest?.CalculateSalary():F2})");
            Console.WriteLine($"  Lowest Earner    : {lowest?.Name}  (₹{lowest?.CalculateSalary():F2})");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  By Employee Type:");
            Console.ResetColor();
            foreach (var g in _payroll.GroupByType())
                Console.WriteLine($"    {g.Key,-12} : {g.Count()} emp(s)  ₹{g.Sum(e => e.CalculateSalary()):F2}/mo");
        }

        private void DepartmentReport()
        {
            Header("DEPARTMENT REPORT");
            foreach (var g in _payroll.GroupByDepartment().OrderBy(g => g.Key))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n  ── {g.Key} ({g.Count()} employee(s)) ──");
                Console.ResetColor();
                foreach (var e in g)
                    Console.WriteLine($"    [{e.Id}] {e.Name,-20} {e.Type,-12} ₹{e.CalculateSalary():F2}");
                Console.WriteLine($"    {"Subtotal",-34} ₹{g.Sum(e => e.CalculateSalary()):F2}");
            }
        }

        // ── SEED DATA ────────────────────────────────────────
        private void SeedData()
        {
            _payroll.Add(new Manager(   "Aisha Sharma",  "aisha@co.com",  Department.Engineering, new DateTime(2019, 3, 1),  85000, 10000));
            _payroll.Add(new Developer( "Rohan Mehta",   "rohan@co.com",  Department.Engineering, new DateTime(2021, 6, 15), 65000, "C#/.NET"));
            _payroll.Add(new Developer( "Priya Patil",   "priya@co.com",  Department.Engineering, new DateTime(2022, 1, 10), 58000, "React/Node"));
            _payroll.Add(new Manager(   "Karan Desai",   "karan@co.com",  Department.HR,          new DateTime(2018, 8, 20), 75000, 8000));
            _payroll.Add(new Developer( "Sneha Joshi",   "sneha@co.com",  Department.Finance,     new DateTime(2023, 4, 1),  52000, "Python"));
            _payroll.Add(new Intern(    "Aryan Shah",    "aryan@uni.com", Department.Engineering, new DateTime(2024, 1, 1),  15000, "VJTI Mumbai", 6));
            _payroll.Add(new Intern(    "Meera Nair",    "meera@uni.com", Department.Marketing,   new DateTime(2024, 2, 1),  12000, "COEP Pune", 3));
        }

        // ── HELPERS ──────────────────────────────────────────
        private Department PickDepartment()
        {
            var depts = Enum.GetValues<Department>();
            Console.WriteLine("  Departments:");
            for (int i = 0; i < depts.Length; i++)
                Console.WriteLine($"    {i + 1}. {depts[i]}");
            Console.Write("  Choose: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= depts.Length)
                return depts[idx - 1];
            return Department.Engineering;
        }

        private DateTime ReadDate(string label)
        {
            while (true)
            {
                Console.Write($"  {label}: ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy",
                    null, System.Globalization.DateTimeStyles.None, out DateTime d))
                    return d;
                Warn("Use format dd/MM/yyyy");
            }
        }

        private string  Prompt(string l)    { Console.Write($"  {l}: "); return Console.ReadLine()?.Trim() ?? ""; }
        private int     ReadInt(string l)   { while (true) { Console.Write($"  {l}: "); if (int.TryParse(Console.ReadLine(), out int v)) return v; Warn("Enter a whole number."); } }
        private decimal ReadDecimal(string l) { while (true) { Console.Write($"  {l}: "); if (decimal.TryParse(Console.ReadLine(), out decimal v) && v >= 0) return v; Warn("Enter a valid amount."); } }
        private void    Header(string t)    { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"  ── {t} ──"); Console.ResetColor(); }
        private void    Success(string m)   { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("  ✔ " + m); Console.ResetColor(); }
        private void    Warn(string m)      { Console.ForegroundColor = ConsoleColor.Red;   Console.WriteLine("  ✘ " + m); Console.ResetColor(); }
    }

    // ─────────────────────────────────────────────────────────
    //  ENTRY POINT
    // ─────────────────────────────────────────────────────────
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            new ConsoleUI().Run();
        }
    }
}