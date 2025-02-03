using System;
using System.ComponentModel.DataAnnotations;

namespace PipperNet.Models
{
  public class Admin
  {
    public int Id { get; set;}
    public string UserId { get; set;} = string.Empty;
    public ApplicationUser? User { get; set;} 
    public DateTime CreatedAt { get; set;} = DateTime.UtcNow;
    public string Role { get; set;} = "Admin";
    public bool IsSuperAdmin { get; set;} = false;
  }
}
