using AppointmentPlanner.Data;
using AppointmentPlanner.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    public AuthController(AppDbContext context) => _context = context;

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == request.Username);
        if (user != null && PasswordHasher.VerifyPassword(request.Password, user.PasswordHash))
        {
            // Map to DTO to avoid exposing sensitive fields
            var userDto = new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Company = user.Company,
                Site = user.Site,
                Email = user.Email,
                Username = user.Username,
                AccessLevel = user.AccessLevel,
                ImageUrl = user.ImageUrl
            };
            return Ok(userDto);
        }
        return Unauthorized();
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}