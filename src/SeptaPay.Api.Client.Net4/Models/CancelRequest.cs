namespace SeptaPay.Api.Client.Net4.Models {
    public class CancelRequest {

        public string ShebaNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ApiKey { get; set; }
        public decimal Amount { get; set; }
        public decimal DividerAmount { get; set; }
        public string Description { get; set; }
        public string FollowId { get; set; }

    }
}
