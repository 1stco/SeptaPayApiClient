using System;
using SeptaPay.Api.Client.Net45.Infrastructure;
using SeptaPay.Api.Client.Net45.Models;
using SeptaPay.Api.Client.Net45.Extensions;
using System.Net.Http;

namespace SeptaPay.Api.Client.Net45 {

    /// <summary>
    /// Payment Services provided by SeptaPay API
    /// </summary>
    public class SeptaPaymentService {

        private readonly HttpClient _client;

        /// <summary>
        /// Instantinate the HttpClient class-wide.
        /// If you want to control HttpClient's requets lifetime yourself, Use the second constructor.
        /// </summary>
        public SeptaPaymentService() {
            _client = new HttpClient() {
                BaseAddress = new Uri(GlobalConstants.__CLIENT_API_URL)
            };
        }

        /// <summary>
        /// Push the [HttpClient] instance to the service for controlling the Http requets lifetime yourself.
        /// </summary>
        /// <param name="httpClient">Your instance of [HttpClient]</param>
        public SeptaPaymentService(HttpClient httpClient) {
            httpClient.CheckArgumentIsNull(nameof(httpClient));
            _client = httpClient;
            _client.BaseAddress = new Uri(GlobalConstants.__CLIENT_API_URL);
        }

        private const string ENDPOINT_NewEpayRequest = "service/NewEpayRequest";
        /// <summary>
        /// Create an [EpayRequest] with the given model and return payment's token and Url.
        /// </summary>
        /// <param name="terminalId">Terminal access key</param>
        /// <param name="apiKey">Your [ApiKey]</param>
        /// <param name="request">[EPayRequest] model to create.</param>
        /// <returns>Payment Url and Payment Token.</returns>
        public EPayRequestResult CreateEpayRequest(Guid terminalId, string apiKey, EPayRequest request) {
            var client = new HttpRestClient<EPayRequest, EPayRequestResult>(_client, ENDPOINT_NewEpayRequest);
            client.WithApiKey(apiKey);
            client.WithTerminalId(terminalId);

            try {
                var result = client.PostJson(request);
                return result;
            }
            catch(Exception ex) {
                return SeptaOperationResult.FailWith<EPayRequestResult>(ex);
            }
        }

        private const string ENDPOINT_CheckEpayRequest = "service/CheckEpayRequest";
        /// <summary>
        /// Check the [EPayRequest] with the given ApiKey and Token.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public EPayRequestCheckResult CheckEPayRequest(string apiKey, string token) {
            var client = new HttpRestClient<string, EPayRequestCheckResult>(_client, ENDPOINT_CheckEpayRequest);
            client.WithApiKey(apiKey);

            try {
                var result = client.PostJson(token);
                return result;
            }
            catch(Exception ex) {
                return SeptaOperationResult.FailWith<EPayRequestCheckResult>(ex);
            }
        }

        private const string ENDPOINT_VerifyApiKey = "service/VerifyApiKey";
        /// <summary>
        /// Verify the given [ApiKey] for User.
        /// </summary>
        /// <param name="apiKey">Your [ApiKey]</param>
        /// <returns>A boolean value representing if [ApiKey] is correct or not.</returns>
        public VerifyApiKeyResult VerifyApiKey(string apiKey) {
            apiKey.CheckReferenceIsNull(nameof(apiKey));

            var client = new HttpRestClient<string, bool>(_client, ENDPOINT_VerifyApiKey);
            client.WithApiKey(apiKey);

            try {
                return VerifyApiKeyResult.Ok(client.Post());
            }
            catch(Exception ex) {
                return VerifyApiKeyResult.Failed(ex);
            }
        }


        private const string ENDPOINT_NewDivideEpayRequest = "service/NewDivideEpayRequest";
        /// <summary>
        /// Create a Divided [EPayRequest] with the given model.
        /// </summary>
        /// <param name="terminalId">Terminal access key</param>
        /// <param name="apiKey">User's (Divider) [ApiKey]</param>
        /// <param name="request">[EPayRequest] model to create</param>
        /// <returns></returns>
        public EPayRequestResult CreateDivideEPayRequest(
            Guid terminalId, 
            string apiKey,
            DividedEPayRequest request)
        {
            request.CheckArgumentIsNull(nameof(request));
            apiKey.CheckArgumentIsNull(nameof(apiKey));

            var client = new HttpRestClient<DividedEPayRequest, EPayRequestResult>
                (_client, ENDPOINT_NewDivideEpayRequest);
            client.WithApiKey(apiKey);
            client.WithTerminalId(terminalId);
            var result = client.PostJson(request);

            return result;
        }


        private const string ENDPOINT_UnblockAmount = "service/UnblockAmount";

        public UnblockAmountResult UnblockAmount(string apiKey, UnblockAmountRequest request) {
            apiKey.CheckArgumentIsNull(nameof(apiKey));
            request.CheckArgumentIsNull(nameof(request));

            var client = new HttpRestClient<UnblockAmountRequest, UnblockAmountResult>(_client, ENDPOINT_UnblockAmount);
            client.WithApiKey(apiKey);
            var result = client.PostJson(request);

            return result;
        }

        private const string ENDPOINT_CancelAmount = "service/CancelAmount";
        public CancelResult CancelAmount(string apiKey, CancelRequest request) {
            apiKey.CheckArgumentIsNull(nameof(apiKey));
            request.CheckArgumentIsNull(nameof(request));

            var client = new HttpRestClient<CancelRequest, CancelResult>(_client, ENDPOINT_CancelAmount);
            client.WithApiKey(apiKey);
            var result = client.PostJson(request);

            return result;
        }

        private const string ENDPOINT_CancelPayment = "service/CancelPayment";

        public bool CancelPayment(string apiKey, string token) {
            apiKey.CheckArgumentIsNull(nameof(apiKey));
            token.CheckArgumentIsNull(nameof(token));

            var client = new HttpRestClient<string, bool>(_client, ENDPOINT_CancelPayment);
            client.WithApiKey(apiKey);
            var result = client.PostJson(token);

            return result;
        }

    }
}
