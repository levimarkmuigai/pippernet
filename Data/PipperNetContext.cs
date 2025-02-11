using PipperNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PipperNet.Data
{
  public class AppDbContext : IdentityDbContext<ApplicationUser>
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


  }
}

