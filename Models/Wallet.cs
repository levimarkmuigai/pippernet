using System.ComponentModel.DataAnnotations;

namespace PipperNet.Models
{
  public class Wallet
  {
    [Key]
    public int Id {get; set;}

    public int ApplicationUserId { get; set;}
    public ApplicationUser? ApplicationUser { get; set;}

    public decimal Balance { get; set;} = 0.00M;
  }
}
