using Bazzar.Domain.Advertisements.ValueObjects;
using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Domain.Advertisements.Events
{
    public class AdvertisementPriceUpdated: IEvents
    {
        public Guid Id { get; set; }
        public long Price { get; set; }
    }
}
