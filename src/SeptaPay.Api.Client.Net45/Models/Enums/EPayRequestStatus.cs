using System.ComponentModel.DataAnnotations;

namespace SeptaPay.Api.Client.Net45.Models.Enums {
    public enum EPayRequestStatus {
        [Display(Name = "آغاز شده")]
        Initiated = 0,
        [Display(Name = "پرداخت شده")]
        Paid = 1,
        [Display(Name = "لغو شده")]
        Cancelled = 2,
        [Display(Name = "منقضی")]
        Expired = 3,
        [Display(Name = "مشاهده شده")]
        Viewed = 4
    }
}
