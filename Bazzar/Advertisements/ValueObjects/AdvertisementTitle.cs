using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Domain.Advertisements.ValueObjects
{
    public class AdvertisementTitle : BaseValueObject<AdvertisementTitle>
    {
        public string Value { get; private set; }
        public static AdvertisementTitle FromString(string value) => new AdvertisementTitle(value);
        public AdvertisementTitle(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("عنوان آگهی نمی تواند خالی باشد");
            }

            Value = value;
        }

        public AdvertisementTitle()
        {
        }

        public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool ObjectIsEqual(AdvertisementTitle otherObject)
        {
           return Value == otherObject;
        }

        public static implicit operator string(AdvertisementTitle advertisementTitle) => advertisementTitle.Value;
    }
}
