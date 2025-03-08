using Microsoft.AspNetCore.Identity;
using System;

namespace PipperNet.Models
{
  public class ApplicationUser : IdentityUser
  {
    
    public string Subscription { get; set;} = string.Empty;
    public string Status { get; set;} = string.Empty;

    public int SubscriptionDuration { get; set; } = 0;

    public Wallet? Wallet { get; set; } 

  }
}
