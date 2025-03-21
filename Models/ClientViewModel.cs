namespace PipperNet.Models
{
    public class ClientViewModel
    {
        public string Subscription { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public int SubscriptionDuration { get; set; } = 0;

        public decimal WalletBalance { get; set; } = 0; 

    }
}
