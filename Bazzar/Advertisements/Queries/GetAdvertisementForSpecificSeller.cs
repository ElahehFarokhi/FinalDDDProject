using System;

namespace Bazzar.Domain.Advertisements.Queries
{
    public class GetAdvertisementForSpecificSeller
    {
        public Guid OwneruserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
