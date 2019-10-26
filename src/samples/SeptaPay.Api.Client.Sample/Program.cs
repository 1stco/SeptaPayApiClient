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
            var _1stTerminal = new Guid("C8A843C9-7BB1-4B4E-9E17-54551FEC36D1");
            var _1stApiKey = "jalalx";
            try {
                _httpClient = new HttpClient();
                var service = new SeptaPaymentService(_httpClient);
                //var result = service.VerifyApiKey(sample_apiKey);
                //Console.WriteLine($"verifying '{sample_apiKey}'-> result : {result.Result.ToString()}");

                var result = service.CreateDivideEPayRequest(_1stTerminal, _1stApiKey, new DividedEPayRequest {
                    Amount = 10000,
                    CallBackUrl = "https://1st.ir/Sales/OrderPayment/PaymentResult",
                    Description = null,
                    Divisions = new List<DividedEPayRequestDivision>() {
                        new DividedEPayRequestDivision {
                            Amount = 9700,
                            ApiKey = "qYqnbxKltqqt4JUwiFLemSfUKUo0Qgzmj4Kj5Jyw",
                            DividerAmount = 300
                        }
                    },
                    ExpiresAfterDays = 10,
                    InvoiceDate = DateTime.Now,
                    InvoiceNumber = "5a4b5c4e-c6fa-425c-a1f8-5507ef06ef20",
                    IsAutoRedirect = true,
                    IsBlocking = true,
                });

            }
            finally {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                _httpClient.Dispose();
            }
        }
    }
}
