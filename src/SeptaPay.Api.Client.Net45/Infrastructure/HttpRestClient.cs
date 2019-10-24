using System;
using System.Net.Http;
using SeptaPay.Api.Client.Net45.Extensions;

namespace SeptaPay.Api.Client.Net45.Infrastructure {
    public class HttpRestClient<T, TResult>: IHttpRestClient<T, TResult> where T: class {

        private readonly HttpClient _client;

        public HttpRestClient(HttpClient httpClient, string endpointAddress) {
            endpointAddress.CheckArgumentIsNull(nameof(endpointAddress));
            EndpointAddress = endpointAddress;
            httpClient.CheckArgumentIsNull(nameof(httpClient));
            _client = httpClient;
        }

        #region Properties

        public string EndpointAddress { get; set; }

        #endregion


        #region Methods

        public void AddHeader(string key, string value) {
            _client.DefaultRequestHeaders.Add(key, value);
        }

        public void WithApiKey(string apiKey) {
            AddHeader("apiKey", apiKey);
        }

        public void WithTerminalId(Guid terminalId) {
            AddHeader("terminalId", terminalId.ToString());
        }

        public TResult PostJson(T request) {
            HttpResponseMessage response = _client.PostAsJsonAsync(EndpointAddress, request).Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsAsync<TResult>().Result;
            return result;
        }

        public TResult Post() {
            HttpResponseMessage response = _client.PostAsync(EndpointAddress, null).Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsAsync<TResult>().Result;
            return result;
        }

        public void Dispose() {
            _client.Dispose();
        }

        #endregion

    }
}
