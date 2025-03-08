using Microsoft.AspNetCore.Mvc;
using Pippernet.Models;

[ApiController]
[Route("api/recharge")]
public class RechargeController : ControllerBase
{
    [HttpPost]
    public IActionResult RechargeAccount([FromBody] RechargeRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.PhoneNumber) || request.Amount <= 0)
        {
            return BadRequest(new { message = "Invalid phone number or amount." });
        }

        var response = new
        {
            PhoneNumber = request.PhoneNumber,
            Amount = request.Amount,
            Status = "Success",
            Message = $"Recharge of {request.Amount} to {request.PhoneNumber} successful!"
        };

        return Ok(response);
    }
}
