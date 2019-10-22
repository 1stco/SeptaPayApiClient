using System;
using SeptaPay.Api.Client.Net4.Models.Enums;

namespace SeptaPay.Api.Client.Net4.Models {
    public class CheckStatusResult {
        public EPayRequestStatus Status { get; set; }
        public string BankReferenceId { get; set; }
        public DateTime? VerifyDate { get; set; }

    }
}
