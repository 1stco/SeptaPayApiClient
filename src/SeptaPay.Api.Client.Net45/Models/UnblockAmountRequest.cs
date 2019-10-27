namespace SeptaPay.Api.Client.Net45.Models {
    public class UnblockAmountRequest: SeptaOperationResult {
        public string PaymentToken { get; set; }
        public string UserApiKey { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal DividerAmount { get; set; }
        public decimal UserAmount { get; set; }
        public string Description { get; set; }
    }
}
