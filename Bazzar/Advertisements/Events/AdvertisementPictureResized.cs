using Framework.Domain.Events;
using System;

namespace Bazzar.Domain.Advertisements.Events
{
    public class AdvertisementPictureResized : IEvents
    {
        public Guid PictureId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
