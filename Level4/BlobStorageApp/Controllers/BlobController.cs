using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BlobController : ControllerBase
{
    private readonly string _conn      = "UseDevelopmentStorage=true";
    private readonly string _container = "mycontainer";

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file provided.");

        var client = new BlobContainerClient(_conn, _container);
        await client.CreateIfNotExistsAsync();

        var blob = client.GetBlobClient(file.FileName);
        using var stream = file.OpenReadStream();
        await blob.UploadAsync(stream, overwrite: true);

        return Ok(new { Message = "File uploaded!", FileName = file.FileName });
    }

    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
        var client = new BlobContainerClient(_conn, _container);
        await client.CreateIfNotExistsAsync();

        var blobs = new List<string>();
        await foreach (var b in client.GetBlobsAsync())
            blobs.Add(b.Name);

        return Ok(blobs);
    }

    [HttpDelete("delete/{fileName}")]
    public async Task<IActionResult> Delete(string fileName)
    {
        var client = new BlobContainerClient(_conn, _container);
        var blob   = client.GetBlobClient(fileName);
        await blob.DeleteIfExistsAsync();
        return Ok($"{fileName} deleted.");
    }
}