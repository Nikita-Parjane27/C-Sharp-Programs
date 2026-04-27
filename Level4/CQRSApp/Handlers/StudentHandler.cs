public class StudentHandler
{
    private static List<Student> _students = new()
    {
        new Student { Id = 1, Name = "Nikita",  Age = 20 },
        new Student { Id = 2, Name = "Ashwini", Age = 21 }
    };
    private static int _nextId = 3;

    // Command Handler
    public Student Handle(CreateStudentCommand command)
    {
        var student = new Student
        {
            Id   = _nextId++,
            Name = command.Name,
            Age  = command.Age
        };
        _students.Add(student);
        return student;
    }

    // Query Handlers
    public List<Student> Handle(GetAllStudentsQuery query)
        => _students;

    public Student Handle(GetStudentByIdQuery query)
        => _students.Find(s => s.Id == query.Id);
}