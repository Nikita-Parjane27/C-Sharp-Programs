
// Controllers/StudentController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private static List<Student> students = new List<Student>
    {
        new Student { Id = 1, Name = "Nikita", Age = 20 },
        new Student { Id = 2, Name = "Ashwini", Age = 21 }
    };

    [HttpGet]
    public IActionResult GetAll() => Ok(students);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var s = students.Find(x => x.Id == id);
        if (s == null) return NotFound("Student not found");
        return Ok(s);
    }

    [HttpPost]
    public IActionResult Add(Student student)
    {
        students.Add(student);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Student updated)
    {
        var s = students.Find(x => x.Id == id);
        if (s == null) return NotFound();
        s.Name = updated.Name;
        s.Age = updated.Age;
        return Ok(s);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var s = students.Find(x => x.Id == id);
        if (s == null) return NotFound();
        students.Remove(s);
        return Ok("Deleted successfully");
    }
}