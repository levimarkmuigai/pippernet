namespace PipperNet.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public string UserId { get; set; }  = string.Empty;
        public ApplicationUser User { get; set; } = null!;
        public decimal Balance { get; set; } = 0;
    }
}
