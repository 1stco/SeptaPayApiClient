namespace SeptaPay.Api.Client.Net4.Models {
    public class EPayRequestResult {
        public EPayRequestResult() { }

        public EPayRequestResult(string token, string absolutePayUrl)
        {
            RequestToken = token;
            PaymentUrl = absolutePayUrl;
        }

        public string RequestToken { get; set; }
        public string PaymentUrl { get; set; }
    }
}
