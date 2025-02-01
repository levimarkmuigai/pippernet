using System;
using System.ComponentModel.DataAnnotations;

namespace PipperNet.Models
{
   public class Payment
   {
     [Key]
     public int Id { get; set;}

     public int ApplicationUserId {get; set;} 
     public ApplicationUser? ApplicationUser { get; set;}

     [Required]
     public string? Phone { get; set;}

     [Required]
     public decimal Amount { get; set;}

     public string TransactionStatus { get; set;} = "Pending"; // "Failed" "Successful"
     public DateTime TransactionDate { get; set;} = DateTime.UtcNow;

   }
}
