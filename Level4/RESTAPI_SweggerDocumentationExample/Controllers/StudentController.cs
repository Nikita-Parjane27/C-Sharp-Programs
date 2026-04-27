// Controllers/StudentController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class StudentController : ControllerBase
{
    private static List<Student> students = new List<Student>
    {
        new Student { Id = 1, Name = "Nikita", Age = 20 },
        new Student { Id = 2, Name = "Ashwini", Age = 21 }
    };

    /// <summary>Get all students</summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<Student>), 200)]
    public IActionResult GetAll() => Ok(students);

    /// <summary>Get student by ID</summary>
    /// <param name="id">Student ID</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Student), 200)]
    [ProducesResponseType(404)]
    public IActionResult GetById(int id)
    {
        var s = students.Find(x => x.Id == id);
        if (s == null) return NotFound("Student not found");
        return Ok(s);
    }

    /// <summary>Add a new student</summary>
    [HttpPost]
    [ProducesResponseType(typeof(Student), 201)]
    public IActionResult Add(Student student)
    {
        students.Add(student);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    /// <summary>Delete a student</summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult Delete(int id)
    {
        var s = students.Find(x => x.Id == id);
        if (s == null) return NotFound();
        students.Remove(s);
        return Ok("Deleted successfully");
    }
}