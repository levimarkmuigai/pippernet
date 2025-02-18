using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using PipperNet.Models;
using PipperNet.Data;

[Route("Admin")]

public class AdminController : Controller
{
  private readonly AppDbContext _context;

  public AdminController (AppDbContext context)
  {
    _context = context;
  }

  // Get Users From Admin Panel
  [HttpGet("GetUsers")]
  public IActionResult GetUsers ()
  {
    var users = _context.ApplicationUser.ToList ();
    return View("Index", users);
  }
  
  // Get specific user by ID
  [HttpGet("GetUserById/{id}")]
  public IActionResult GetUserById(string id)
  {
    var user = _context.ApplicationUser.FirstOrDefault(u => u.Id == id);
    if (user == null)

    {
      return NotFound();
    }
    return Json (user);
  }

  // Edit user details
  [HttpPut("EditUser/{id}")]
  public IActionResult EditUser(string id, [FromBody] ApplicationUser updatedUser)
  {
    if (updatedUser == null)
    {
      return BadRequest("Invalid user data.");
    }
    var user = _context.ApplicationUser.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
      return NotFound();
    }

    // Update the user's properties
    user.Email = updatedUser.Email;
    user.Subscription = updatedUser.Subscription;
    user.Status = updatedUser.Status;

    _context.SaveChanges();

    return Json(user);
  }
}
