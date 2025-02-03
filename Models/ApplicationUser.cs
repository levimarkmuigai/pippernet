using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PipperNet.Models
{
  public class ApplicationUser : IdentityUser<int>
  {
    public string Name { get; set;}  = string.Empty;
    public string Role { get; set;}  = string.Empty;

    // Navigation.
    public Subscription? Subscription { get; set;}
    public Wallet? Wallet { get; set;}
    public List<Payment>? Payments { get; set;} 
  }
}
