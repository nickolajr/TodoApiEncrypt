using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/todo")]
public class TodoApiEncryptController : ControllerBase
{
    private readonly IRSAEncryptionService _encryptionService;

    public TodoApiEncryptController(IRSAEncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
    }

    [HttpPost("encrypt")]
    public async Task<IActionResult> EncryptTodoItem([FromBody] EncryptRequest request)
    {
        // Validate the input
        if (string.IsNullOrEmpty(request.TodoItem) || string.IsNullOrEmpty(request.PublicKey))
        {
            return BadRequest("To-Do item and public key cannot be empty.");
        }

        // Encrypt the To-Do item using the provided public key
        try
        {
            // Call the encryption service to encrypt the Todo item
            var encryptedItem = await _encryptionService.Encrypt(request.TodoItem, request.PublicKey);

            // Return the encrypted item directly without extra fields
            return Ok(encryptedItem);
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur during encryption
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

public class EncryptRequest
{
    public string TodoItem { get; set; }
    public string PublicKey { get; set; }
}
