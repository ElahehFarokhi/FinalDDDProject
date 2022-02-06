using System.ComponentModel;

namespace Bazzar.Domain.Advertisements.Entities
{
    public enum AdvertisementState
    {
        [Description("غیرفعال")]
        Inactive = 1,
        [Description("در انتظار تایید")]
        ReviewPending = 2,
        [Description("فعال")]
        Active = 3,
        [Description("فروخته شده")]
        Sold = 4
    }


    // without value object
    //public enum AdvertisementStatus
    //{
    //    New = 1,
    //    WaitingForReview = 2,
    //    Published = 3,
    //    Disabled = 4
    //}
}
