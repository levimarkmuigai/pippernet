using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PipperNet.Models;
using System.Threading.Tasks;

namespace PipperNet.Controllers
{
    [Authorize(Roles = "Client")] // Restricts access to Clients only
    public class ClientController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ClientController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Retrieve the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(); // If user data is missing
            }

            // Pass subscription & status to the view
            var viewModel = new ClientViewModel
            {
                Subscription = user.Subscription, // Assigned by Admin
                Status = user.Status, // Assigned by Admin
                SubscriptionDuration = user.SubscriptionDuration // Assigned by Admin
            };

            return View(viewModel); // Render Client Dashboard
        }
    }
}
