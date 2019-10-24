using System;

namespace SeptaPay.Api.Client.Net45.Models {
    public class CancelPaymentResult: SeptaOperationResult {
        public bool Result { get; set; }

        public static CancelPaymentResult Ok(bool result) {
            return new CancelPaymentResult {
                Result = result,
                Success = true
            };
        }

        public static CancelPaymentResult Failed(Exception ex) {
            return new CancelPaymentResult {
                Exception = ex,
                Message = ex.GetBaseException().Message,
                Result = false,
                Success = false
            };
        }
    }
}
