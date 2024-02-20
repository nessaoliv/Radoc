using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UserAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>
        {
            {"user1", "password1"},
            {"user2", "password2"}
        };

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (_users.TryGetValue(request.Username!, out string? password) && password == request.Password)
            {
                // Autenticação bem-sucedida
                return Ok(new { Message = "Login successful" });
            }

            // Autenticação falhou
            return Unauthorized(new { Message = "Invalid username or password" });
        }
    }

    public class LoginRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
