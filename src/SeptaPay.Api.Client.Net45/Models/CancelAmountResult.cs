using System;

namespace SeptaPay.Api.Client.Net45.Models {
    public class CancelAmountResult: SeptaOperationResult {
        public decimal CancelledAmount { get; set; }

        public static CancelAmountResult Ok(decimal cancelledAmount) { 
            return new CancelAmountResult { 
                CancelledAmount = cancelledAmount,
                Success = true
            };
        }

        public static CancelAmountResult Failed(Exception ex) {
            return new CancelAmountResult {
                Exception = ex,
                Message = ex.GetBaseException().Message,
                Success = false
            };
        }
    }
}
