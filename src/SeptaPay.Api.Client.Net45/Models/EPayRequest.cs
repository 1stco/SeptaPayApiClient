using System;

namespace SeptaPay.Api.Client.Net45.Models {
    public class EPayRequest: SeptaOperationResult {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int ExpiresAfterDays { get; set; }
        public string Bearer { get; set; }
        public decimal Amount { get; set; }
        public string CallBackUrl { get; set; }
        public string Description { get; set; }
        public bool IsAutoRedirect { get; set; }
    }
}
