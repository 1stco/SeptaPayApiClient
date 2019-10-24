using System;

namespace SeptaPay.Api.Client.Net45.Models {
    public class VerifyApiKeyResult: SeptaOperationResult {
        public bool Result { get; set; }

        public static VerifyApiKeyResult Ok(bool result) {
            return new VerifyApiKeyResult {
                Result = result,
                Success = true
            };
        }

        public static VerifyApiKeyResult Failed(Exception ex) {
            return new VerifyApiKeyResult {
                Exception = ex,
                Message = ex.GetBaseException().Message,
                Result = false,
                Success = false
            };
        }
    }
}
