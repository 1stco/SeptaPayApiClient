using System;
using SeptaPay.Api.Client.Net45.Models.Enums;

namespace SeptaPay.Api.Client.Net45.Models {
    public class CheckStatusResult: SeptaOperationResult {
        public EPayRequestStatus Status { get; set; }
        public string BankReferenceId { get; set; }
        public DateTime? VerifyDate { get; set; }

    }
}
