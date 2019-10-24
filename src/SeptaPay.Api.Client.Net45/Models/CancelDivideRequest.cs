namespace SeptaPay.Api.Client.Net45.Models {
    public class CancelDivideRequest: SeptaOperationResult {
        public string UserApiKey { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal DividerAmount { get; set; }
        public decimal UserAmount { get; set; }
        public string ShebaNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
    }
}
