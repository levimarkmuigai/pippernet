namespace Pippernet.Models
{
    public class RechargeRequest
    {
        public string PhoneNumber { get; set; } = string.Empty;
        
        public decimal Amount { get; set; } = 0;

        public string Status { get; set; } = string.Empty;
        
    }
}