using Framework.Domain.Events;
using System;

namespace Bazzar.Domain.Advertisements.Events
{
    public class PictureAddedToAdvertisement : IEvents
    {
        public Guid ClassifiedAdId { get; set; }
        public Guid PictureId { get; set; }
        public string Url { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Order { get; set; }
    }
}
