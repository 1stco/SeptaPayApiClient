using System;
using System.Collections.Generic;

namespace SeptaPay.Api.Client.Net4.Models {
    public class DividedEPayRequest {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public ushort ExpiresAfterDays { get; set; }
        public decimal Amount { get; set; }
        public string CallBackUrl { get; set; }
        public string Description { get; set; }
        public bool IsAutoRedirect { get; set; }
        public List<DividedEPayRequestDivision> Divisions { get; set; }
        public bool IsBlocking { get; set; }
    }
}
