using System;
using SeptaPay.Api.Client.Net4.Infrastructure;
using SeptaPay.Api.Client.Net4.Models;
using SeptaPay.Api.Client.Net4.Extensions;

namespace SeptaPay.Api.Client.Net4 {
    public class SeptaPaymentService {

        public SeptaPaymentService() { 
        }


        private const string ENDPOINT_NewEpayRequest = "service/NewEpayRequest";
        public EPayRequestResult CreateEpayRequest(Guid terminalId, string apiKey, EPayRequest request) {
            var client = new HttpRestClient<EPayRequest, EPayRequestResult>(ENDPOINT_NewEpayRequest);
            client.WithApiKey(apiKey);
            client.WithTerminalId(terminalId);
            var result = client.PostJson(request);

            return result;
        }

        private const string ENDPOINT_CheckEpayRequest = "service/CheckEpayRequest";

        public EPayRequestCheckResult CheckEPayRequest(string apiKey, string token) {
            var client = new HttpRestClient<string, EPayRequestCheckResult>(ENDPOINT_CheckEpayRequest);
            client.WithApiKey(apiKey);
            var result = client.PostJson(token);

            return result;
        }

        private const string ENDPOINT_VerifyApiKey = "service/VerifyApiKey";

        public bool VerifyApiKey(string apiKey) {
            apiKey.CheckReferenceIsNull(nameof(apiKey));

            var client = new HttpRestClient<string, bool>(ENDPOINT_VerifyApiKey);
            client.WithApiKey(apiKey);
            var result = client.Post();

            return result;
        }


    }
}
