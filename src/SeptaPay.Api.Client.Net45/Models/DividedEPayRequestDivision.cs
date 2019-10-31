namespace SeptaPay.Api.Client.Net45.Models {
    public class DividedEPayRequestDivision {
        public string ApiKey { get; set; }
        public decimal Amount { get; set; }
        public decimal DividerAmount { get; set; }
        public string InvoiceNumber { get; set; }
    }
}
