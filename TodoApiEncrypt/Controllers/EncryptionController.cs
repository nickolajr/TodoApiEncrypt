using Microsoft.AspNetCore.Mvc;

namespace TodoApiEncrypt.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class TodoApiEncryptController : ControllerBase
    {
        private readonly IAESEncryptionService _aesEncryption;

        public TodoApiEncryptController(IAESEncryptionService aesEncryption)
        {
            _aesEncryption = aesEncryption;
        }

        [HttpPost("encrypt")]
        public IActionResult EncryptTodoItem([FromBody] string todoItem)
        {
            if (string.IsNullOrEmpty(todoItem))
            {
                return BadRequest("To-Do item cannot be empty");
            }

            // Encrypt the items
            var encryptedItem = _aesEncryption.Encrypt(todoItem);
            return Ok(encryptedItem);
        }

        //[HttpPost("decrypt")]
        //public IActionResult DecryptTodoItem([FromBody] string encryptedTodoItem)
        //{
        //    if (string.IsNullOrEmpty(encryptedTodoItem))
        //    {
        //        return BadRequest("Encrypted To-Do item cannot be empty");
        //    }

        //    // Decrypt the items
        //    var decryptedItem = _aesEncryption.Decrypt(encryptedTodoItem);
        //    return Ok(decryptedItem);
        //}
    }
}
