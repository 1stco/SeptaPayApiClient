namespace SeptaPay.Api.Client.Net45.Models {
    public class UnblockAmountResult: SeptaOperationResult {
        public decimal UnblockedAmount { get; set; }

        public static UnblockAmountResult Ok(decimal amount) { 
            return new UnblockAmountResult { 
                Success = true,
                UnblockedAmount = amount
            };
        }
    }
}
