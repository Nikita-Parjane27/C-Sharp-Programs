using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly string _uploadFolder = "Uploads";

    public FileController()
    {
        if (!Directory.Exists(_uploadFolder))
            Directory.CreateDirectory(_uploadFolder);
    }

    // Upload
    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        string filePath = Path.Combine(_uploadFolder, file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        return Ok(new { Message = "File uploaded!", FileName = file.FileName });
    }

    // Download
    [HttpGet("download/{fileName}")]
    public IActionResult Download(string fileName)
    {
        string filePath = Path.Combine(_uploadFolder, fileName);

        if (!System.IO.File.Exists(filePath))
            return NotFound("File not found.");

        byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
        string mimeType  = "application/octet-stream";

        return File(fileBytes, mimeType, fileName);
    }

    // List uploaded files
    [HttpGet("list")]
    public IActionResult ListFiles()
    {
        var files = Directory.GetFiles(_uploadFolder)
                             .Select(Path.GetFileName)
                             .ToList();
        return Ok(files);
    }
}