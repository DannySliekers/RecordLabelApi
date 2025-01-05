namespace RecordLabelApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using RecordLabelApi.Context;
    using RecordLabelApi.Models;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly RecordLabelContext _context;

        public AuthController(RecordLabelContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.username == request.Username);
            
            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid username or password." });
            }

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.passwordhash);
            
            if (!isPasswordValid)
            {
                return Unauthorized(new { Message = "Invalid username or password." });
            }

            var token = GenerateJwtToken(user.username);

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (await _context.User.AnyAsync(u => u.username == request.Username))
            {
                return BadRequest(new { Message = "Username is already taken." });
            }

            if (await _context.User.AnyAsync(u => u.email == request.Email))
            {
                return BadRequest(new { Message = "Email is already in use." });
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                username = request.Username,
                email = request.Email,
                passwordhash = passwordHash
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User registered successfully." });
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-very-strong-secret-keyqwqwwqqwqwqw"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "your-issuer",
                audience: "your-audience",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
