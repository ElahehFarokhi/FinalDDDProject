using Framework.Domain.ValueObjects;
using System;

namespace Bazzar.Domain.Advertisements.ValueObjects
{

    public class Price : BaseValueObject<Price>
    {
        public Rial Value { get; private set; }
        public static Price FromString(string value) => new Price(Rial.FromString(value));
        public static Price FromLong(long value) => new Price(Rial.FromLong(value));

        public Price(Rial rial)
        {
            if (rial < 1)
            {
                throw new ArgumentOutOfRangeException("مقدار قیمت کمتر از یک ريال نمی تواند باشد");
            }
            Value = rial;
        }
        private Price()
        {

        }

        public override bool ObjectIsEqual(Price otherObject)
        {
            return otherObject.Value == this.Value;
        }

        public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }

        public static implicit operator long(Price price) => price.Value;

    }
}
