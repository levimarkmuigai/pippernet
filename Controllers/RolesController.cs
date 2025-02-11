using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PipperNet.Controllers
{
  public class RolesController : Controller
  {

    private readonly RoleManager<IdentityRole> _manager;

    public RolesController(RoleManager<IdentityRole> rolemanager)
    {
      _manager = rolemanager;
    }
    public IActionResult Index()
    {
      var roles = _manager.Roles;
      return View(roles);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create (IdentityRole role)
    {
      // Check If Role exsists
      if(role.Name != null && !await _manager.RoleExistsAsync(role.Name))
      {
        await _manager.CreateAsync(new IdentityRole(role.Name));
      }
      return RedirectToAction("Index");
    }

  }
}

