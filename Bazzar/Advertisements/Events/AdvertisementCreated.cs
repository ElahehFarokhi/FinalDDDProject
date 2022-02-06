using Framework.Domain.Events;
using System;

namespace Bazzar.Domain.Advertisements.Events
{
    public class AdvertisementCreated: IEvents
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
    }
}
