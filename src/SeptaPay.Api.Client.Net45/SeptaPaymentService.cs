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

        private readonly HttpClient _httpClient;

        /// <summary>
        /// Instantinate the HttpClient class-wide.
        /// If you want to control HttpClient's requets lifetime yourself, Use the second constructor.
        /// </summary>
        public SeptaPaymentService() {
            _httpClient = new HttpClient() {
                BaseAddress = new Uri(GlobalConstants.__CLIENT_API_URL)
            };
        }

        /// <summary>
        /// Push the [HttpClient] instance to the service for controlling the Http requets lifetime yourself.
        /// </summary>
        /// <param name="httpClient">Your instance of [HttpClient]</param>
        public SeptaPaymentService(HttpClient httpClient) {
            httpClient.CheckArgumentIsNull(nameof(httpClient));
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(GlobalConstants.__CLIENT_API_URL);
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
            var client = new HttpRestClient<EPayRequest, EPayRequestResult>(_httpClient, ENDPOINT_NewEpayRequest);
            client.WithApiKey(apiKey);
            client.WithTerminalId(terminalId);

            try {
                return client.PostJson(request);
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
            var client = new HttpRestClient<string, EPayRequestCheckResult>(_httpClient, ENDPOINT_CheckEpayRequest);
            client.WithApiKey(apiKey);

            try {
                return client.PostJson(token);
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

            var client = new HttpRestClient<string, bool>(_httpClient, ENDPOINT_VerifyApiKey);
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
        /// <returns>Payment Token and Url</returns>
        public EPayRequestResult CreateDivideEPayRequest(Guid terminalId, 
            string apiKey,
            DividedEPayRequest request) 
        {
            request.CheckArgumentIsNull(nameof(request));
            apiKey.CheckArgumentIsNull(nameof(apiKey));

            var client = new HttpRestClient<DividedEPayRequest, EPayRequestResult>
                (_httpClient, ENDPOINT_NewDivideEpayRequest);

            client.WithApiKey(apiKey);
            client.WithTerminalId(terminalId);

            try {
                return client.PostJson(request);
            }
            catch(Exception ex) {
                return SeptaOperationResult.FailWith<EPayRequestResult>(ex);
            }
        }


        private const string ENDPOINT_UnblockAmount = "service/UnblockAmount";
        /// <summary>
        /// Unblock amount of an [EPayRequest]
        /// </summary>
        /// <param name="apiKey">Divider User [ApiKey]</param>
        /// <param name="request">Divide Unblock amount request model</param>
        /// <returns></returns>
        public UnblockAmountResult UnblockAmount(string apiKey, UnblockAmountRequest request) {

            apiKey.CheckArgumentIsNull(nameof(apiKey));
            request.CheckArgumentIsNull(nameof(request));

            var client = new HttpRestClient<UnblockAmountRequest, UnblockAmountResult>
                (_httpClient, ENDPOINT_UnblockAmount);
            client.WithApiKey(apiKey);

            try {
                var svcResult = client.PostJson(request);
                return UnblockAmountResult.Ok(svcResult.UnblockedAmount);
            }
            catch(Exception ex) {
                return SeptaOperationResult.FailWith<UnblockAmountResult>(ex);
            }
        }

        private const string ENDPOINT_CancelAmount = "service/CancelAmount";
        /// <summary>
        /// Cancel the payment amount and Refund it's amount
        /// </summary>
        /// <param name="apiKey">Divider [ApiKey]</param>
        /// <param name="request">Cancel amount request model</param>
        /// <returns></returns>
        public CancelAmountResult CancelAmount(string apiKey, CancelAmountRequest request) {

            apiKey.CheckArgumentIsNull(nameof(apiKey));
            request.CheckArgumentIsNull(nameof(request));

            var client = new HttpRestClient<CancelAmountRequest, CancelAmountResult>
                (_httpClient, ENDPOINT_CancelAmount);
            client.WithApiKey(apiKey);

            try {
                var svcResult = client.PostJson(request);
                return CancelAmountResult.Ok(svcResult.CancelledAmount);
            }
            catch(Exception ex) {
                return CancelAmountResult.Failed(ex);
            }
        }

        private const string ENDPOINT_CancelPayment = "service/CancelPayment";
        /// <summary>
        /// Cancel payment based on the given Token.
        /// </summary>
        /// <param name="apiKey">Divider [ApiKey]</param>
        /// <param name="token">Payment token</param>
        /// <returns>A boolean value representing if cancel process is successful or not.</returns>
        public CancelPaymentResult CancelPayment(string apiKey, string token) {

            apiKey.CheckArgumentIsNull(nameof(apiKey));
            token.CheckArgumentIsNull(nameof(token));

            var client = new HttpRestClient<string, bool>(_httpClient, ENDPOINT_CancelPayment);
            client.WithApiKey(apiKey);

            try {
                var result = client.PostJson(token);
                return CancelPaymentResult.Ok(result);
            }
            catch(Exception ex) {
                return CancelPaymentResult.Failed(ex);
            }
        }

    }
}
