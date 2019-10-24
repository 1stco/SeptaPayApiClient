using System;

namespace SeptaPay.Api.Client.Net45.Models {
    public abstract class SeptaOperationResult {
        public string Message { get; set; }
        public bool Success { get; set; }
        public Exception Exception { get; set; }

        public static T FailWith<T>(Exception ex) where T : SeptaOperationResult, new() {
            return new T {
                Exception = ex,
                Success = false,
                Message = ex.GetBaseException().Message
            };
        }
    }
}
