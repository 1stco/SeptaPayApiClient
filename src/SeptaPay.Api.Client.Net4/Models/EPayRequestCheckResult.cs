using System;
using SeptaPay.Api.Client.Net4.Models.Enums;

namespace SeptaPay.Api.Client.Net4.Models {
    public class EPayRequestCheckResult {

        public EPayRequestCheckResult() { }

        public EPayRequestCheckResult(CheckStatusResult result) {
            BankReferenceId = result.BankReferenceId;
            RequestStatus = result.Status;
            VerifyDate = result.VerifyDate;
        }


        public string BankReferenceId { get; set; }
        public EPayRequestStatus RequestStatus { get; set; }
        public DateTime? VerifyDate { get; set; }
    }
}
