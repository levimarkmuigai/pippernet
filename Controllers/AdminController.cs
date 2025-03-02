using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using PipperNet.Models;
using PipperNet.Data;

[Route("Admin")]
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
        var users = await _context.ApplicationUser.ToListAsync();
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

        // Validate Subscription & Status
        var validSubscriptions = new[] { "Basic", "Standard", "Premium" };
        var validStatuses = new[] { "Active", "Inactive" };

        if (!validSubscriptions.Contains(updatedUser.Subscription) || !validStatuses.Contains(updatedUser.Status))
        {
            return BadRequest("Invalid Subscription or Status value.");
        }

        // Update only allowed properties
        user.Subscription = updatedUser.Subscription;
        user.Status = updatedUser.Status;

        await _context.SaveChangesAsync();
        return Json(user);
    }
}
