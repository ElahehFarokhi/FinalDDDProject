using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Domain.Advertisements.ValueObjects
{
    public class AdvertisementText : BaseValueObject<AdvertisementText>
    {
        public string Value { get; private set; }
        public static AdvertisementText FromString(string value) => new AdvertisementText(value);
        public AdvertisementText(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("متن آگهی نمی تواند خالی باشد");
            }
            if (value.Length<100)
            {
                throw new ArgumentOutOfRangeException("حداقل طول متن آگهی صد کاراکتر می باشد");
            }

            Value = value;
        }
            
        public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool ObjectIsEqual(AdvertisementText otherObject)
        {
            return Value == otherObject.Value;
        }
    }
}
