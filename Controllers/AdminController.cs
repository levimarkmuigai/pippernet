using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using PipperNet.Models;
using PipperNet.Data;

[Route("Admin")]
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    // Get Users From Admin Panel
   [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var adminRoleId = await _context.Roles
            .Where(r => r.Name == "Admin")
            .Select(r => r.Id)
            .FirstOrDefaultAsync();

        var users = await _context.ApplicationUser
            .Where(u => !_context.UserRoles
            .Any(ur => ur.UserId == u.Id && ur.RoleId == adminRoleId))
            .ToListAsync();

        return View("Index", users);
    }


    // Get specific user by ID
    [HttpGet("GetUserById/{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var user = await _context.ApplicationUser.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return Json(user);
    }

    // Edit user details
    [HttpPut("EditUser/{id}")]
    public async Task<IActionResult> EditUser(string id, [FromBody] ApplicationUser updatedUser)
    {
        if (updatedUser == null)
        {
            return BadRequest("Invalid user data.");
        }

        var user = await _context.ApplicationUser.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        // Validate Subscription,Status & Duration
        var validSubscriptions = new[] { "Basic", "Standard", "Premium" };
        var validStatuses = new[] { "Active", "Inactive" };
        var validateDurations = new[] { 30,90,120 };

        if (!validSubscriptions.Contains(updatedUser.Subscription) || !validStatuses.Contains(updatedUser.Status))
        {
            return BadRequest("Invalid Subscription,Status or Duration value.");
        }

        // Update only allowed properties
        user.Subscription = updatedUser.Subscription;
        user.Status = updatedUser.Status;
        user.SubscriptionDuration = updatedUser.SubscriptionDuration;

        await _context.SaveChangesAsync();
        return Json(user);
    }
}
