using System;

namespace Bazzar.Domain.Advertisements.Dtoes
{
    public class AdvertisementSummary
    {
        public Guid AdvertisementId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
    }
}
