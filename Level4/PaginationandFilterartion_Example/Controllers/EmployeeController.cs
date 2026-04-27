using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private static List<Employee> employees = new List<Employee>
    {
        new Employee { Id=1, Name="Nikita",    Department="IT",      Salary=50000 },
        new Employee { Id=2, Name="Ashwini",   Department="HR",      Salary=45000 },
        new Employee { Id=3, Name="Shubhangi", Department="IT",      Salary=55000 },
        new Employee { Id=4, Name="Gayatri",   Department="Finance", Salary=48000 },
        new Employee { Id=5, Name="Ravi",      Department="IT",      Salary=60000 },
        new Employee { Id=6, Name="Priya",     Department="HR",      Salary=42000 },
        new Employee { Id=7, Name="Amit",      Department="Finance", Salary=52000 },
        new Employee { Id=8, Name="Sneha",     Department="IT",      Salary=58000 },
    };

    // GET api/employee?department=IT&page=1&pageSize=3
    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] string department = null,
        [FromQuery] int page          = 1,
        [FromQuery] int pageSize      = 3)
    {
        var query = employees.AsQueryable();

        // Filter
        if (!string.IsNullOrEmpty(department))
            query = query.Where(e => e.Department.ToLower() == department.ToLower());

        int totalRecords = query.Count();

        // Pagination
        var result = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return Ok(new
        {
            TotalRecords = totalRecords,
            Page         = page,
            PageSize     = pageSize,
            TotalPages   = (int)Math.Ceiling((double)totalRecords / pageSize),
            Data         = result
        });
    }
}