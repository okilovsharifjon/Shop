namespace OsonCommerce.Domain.Entities
{
    public class OnlineCashbox : Cashbox
    {
        public string PaymentGateway { get; set; } // Платежный шлюз
        
    }
}