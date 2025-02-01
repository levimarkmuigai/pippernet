using System;
using System.ComponentModel.DataAnnotations;

namespace PipperNet.Models
{
  public class Subscription
  {
    [Key]
    public int Id { get; set;}

    public int ApplicationUserId { get; set;}
    public ApplicationUser? ApplicationUser { get; set;}

    [Required]
    public string? PlanName { get; set;}

    [Required]
    public string Status { get; set;} = "Inactive"; // "Active"

    public DateTime? Expiry { get; set;}

  }
}
