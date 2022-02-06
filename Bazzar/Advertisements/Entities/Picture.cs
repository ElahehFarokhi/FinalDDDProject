using Bazzar.Domain.Advertisements.Events;
using Bazzar.Domain.Advertisements.ValueObjects;
using Framework.Domain.Entities;
using Framework.Domain.Events;
using System;

namespace Bazzar.Domain.Advertisements.Entities
{
    public class Picture : BaseEntity<Guid>
    {
        public PictureSize Size { get; set; }
        public PictureURL Location { get; set; }
        public int Order { get; set; }
        public Picture(Action<IEvents> applier):base(applier)
        {

        }
        public Picture()
        {

        }

        public void Resize(PictureSize newSize)
        {
            SetStateByEvent(new AdvertisementPictureResized()
            {
                PictureId = Id,
                Width = newSize.Width,
                Height = newSize.Height
            }
            );
        }

        protected override void SetStateByEvent(IEvents @event)
        {
            switch (@event)
            {
                case PictureAddedToAdvertisement e:
                    Id = e.PictureId;
                    Location = PictureURL.FromString(e.Url);
                    Size = new PictureSize(e.Height, e.Width);
                    Order = e.Order;
                    break;
                case AdvertisementPictureResized e:
                    Size = new PictureSize(e.Height, e.Width);
                    break;
                default:
                    break;
            }
        }
    }
}