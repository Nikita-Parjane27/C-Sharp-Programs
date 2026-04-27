using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("not-found")]
    public IActionResult NotFoundError()
        => throw new NotFoundException("Student with ID 99 not found.");

    [HttpGet("validation")]
    public IActionResult ValidationError()
        => throw new ValidationException("Age must be between 1 and 100.");

    [HttpGet("unauthorized")]
    public IActionResult UnauthorizedError()
        => throw new UnauthorizedException("You don't have permission to access this.");

    [HttpGet("business")]
    public IActionResult BusinessError()
        => throw new BusinessException("Cannot delete student with active enrollments.");

    [HttpGet("server-error")]
    public IActionResult ServerError()
        => throw new Exception("Unexpected server error occurred.");

    [HttpGet("success")]
    public IActionResult Success()
        => Ok("Everything working fine!");
}