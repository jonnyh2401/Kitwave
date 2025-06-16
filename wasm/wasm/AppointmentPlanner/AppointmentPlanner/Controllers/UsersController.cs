using AppointmentPlanner.Client;
using AppointmentPlanner.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Use the correct namespace for your PasswordHasher
using AppointmentPlanner.Client; // If PasswordHasher is in AppointmentPlanner.Client

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<User>> Get(string username)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        if (user == null) return NotFound();
        return user;
    }

    [HttpPost]
    public async Task<IActionResult> Add(User user)
    {
        // Hash the password before saving
        if (!string.IsNullOrWhiteSpace(user.PasswordHash))
        {
            user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);
        }
        else
        {
            return BadRequest("Password is required.");
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, User user)
    {
        if (id != user.UserId) return BadRequest();

        var existingUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == id);
        if (existingUser == null) return NotFound();

        // If a new password is provided, hash it; otherwise, keep the old hash
        if (!string.IsNullOrWhiteSpace(user.PasswordHash) && user.PasswordHash != existingUser.PasswordHash)
        {
            user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);
        }
        else
        {
            user.PasswordHash = existingUser.PasswordHash;
        }

        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return Ok();
    }

    // --- Change Password Endpoint ---
    [HttpPut("{id}/change-password")]
    public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordRequest model)
    {
        if (model == null || string.IsNullOrWhiteSpace(model.CurrentPassword) || string.IsNullOrWhiteSpace(model.NewPassword))
            return BadRequest("Invalid request.");

        if (model.NewPassword.Length < 6)
            return BadRequest("New password must be at least 6 characters.");

        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return NotFound();

        // Verify current password
        if (!PasswordHasher.VerifyPassword(model.CurrentPassword, user.PasswordHash))
            return BadRequest("Current password is incorrect.");

        // Update password hash
        user.PasswordHash = PasswordHasher.HashPassword(model.NewPassword);
        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return Ok();
    }

    public class ChangePasswordRequest
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}