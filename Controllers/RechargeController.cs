using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PipperNet.Data;
using PipperNet.Models;

[ApiController]
[Route("api/recharge")]
public class RechargeController : ControllerBase
{
    private readonly AppDbContext _context;

    public RechargeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult RechargeAccount([FromBody] RechargeRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.PhoneNumber) || request.Amount <= 0)
        {
            return BadRequest(new { message = "Invalid phone number or amount." });
        }

        // Find the user by phone number
        var user = _context.ApplicationUser
            .Include(u => u.Wallet)
            .FirstOrDefault(u => u.PhoneNumber == request.PhoneNumber);

        if (user == null)
        {
            return NotFound(new { message = "User not found." });
        }

        // If user has no wallet, create one
        if (user.Wallet == null)
        {
            user.Wallet = new Wallet
            {
                UserId = user.Id,
                Balance = 0
            };
            _context.Wallets.Add(user.Wallet);
        }

        // Update wallet balance
        user.Wallet.Balance += request.Amount;
        _context.SaveChanges();

        var response = new
        {
            PhoneNumber = request.PhoneNumber,
            Amount = request.Amount,
            NewBalance = user.Wallet.Balance,
            Status = "Success",
            Message = $"Recharge of {request.Amount} successful! New balance: {user.Wallet.Balance}"
        };

        return Ok(response);
    }
}
