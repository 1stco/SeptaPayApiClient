using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SeptaPay.Api.Client.Net45;
using SeptaPay.Api.Client.Net45.Models;

namespace SeptaPay.Api.Client.Sample
{
    class Program
    {
        static HttpClient _httpClient;
        static string sample_apiKey = "hdGnjBjfiqK7dRorUeL9NNq34VaotxrFZHHj1xw7";

        static void Main(string[] args)
        {

            try {
                _httpClient = new HttpClient();
                var service = new SeptaPaymentService(_httpClient);
                var result = service.VerifyApiKey(sample_apiKey);
                Console.WriteLine($"verifying '{sample_apiKey}'-> result : {result.Result.ToString()}");
            }
            finally {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                _httpClient.Dispose();
            }
        }
    }
}
