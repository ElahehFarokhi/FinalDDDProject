using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Domain.Advertisements.Events
{
    public class AdvertisementTitleChanged : IEvents
    {
        public Guid Id { get; set; }
        public string AdvertisementTitle { get; set; }
    }
}
