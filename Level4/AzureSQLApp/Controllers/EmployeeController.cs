using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _db;
    public EmployeeController(AppDbContext db) { _db = db; }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _db.Employees.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Add(Employee emp)
    {
        _db.Employees.Add(emp);
        await _db.SaveChangesAsync();
        return Ok(emp);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var emp = await _db.Employees.FindAsync(id);
        if (emp == null) return NotFound();
        _db.Employees.Remove(emp);
        await _db.SaveChangesAsync();
        return Ok("Deleted!");
    }
}