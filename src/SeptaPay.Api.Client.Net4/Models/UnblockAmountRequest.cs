namespace SeptaPay.Api.Client.Net4.Models {
    public class UnblockAmountRequest {
        public string UserApiKey { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal DividerAmount { get; set; }
        public decimal UserAmount { get; set; }
        public string Description { get; set; }
    }
}
