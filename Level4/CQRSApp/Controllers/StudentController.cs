using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentHandler _handler;

    public StudentController(StudentHandler handler)
    {
        _handler = handler;
    }

    [HttpGet]
    public IActionResult GetAll()
        => Ok(_handler.Handle(new GetAllStudentsQuery()));

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var s = _handler.Handle(new GetStudentByIdQuery { Id = id });
        if (s == null) return NotFound();
        return Ok(s);
    }

    [HttpPost]
    public IActionResult Create(CreateStudentCommand command)
        => Ok(_handler.Handle(command));
}