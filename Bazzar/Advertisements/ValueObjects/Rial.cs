using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Domain.Advertisements.ValueObjects
{
    public class Rial : BaseValueObject<Rial>
    {
        public long Value { get; private set; }
        public static Rial FromString(string value) => new Rial(long.Parse(value));
        public static Rial FromLong(long value) => new Rial(value);

        protected Rial(long value)
        {
            Value = value;
        }

        private Rial()
        { 
        
        }

        public Rial Add(Rial rial)
        {
            return new Rial(Value + rial.Value);
        }
        public Rial Subtract(Rial rial)
        {
            return new Rial(Value - rial.Value);
        }

        public override bool ObjectIsEqual(Rial otherObject)
        {
            return Value == otherObject.Value;
        }

        public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }

        public static Rial operator +(Rial left, Rial right)
        {
            return left.Add(right);
        }

        public static Rial operator -(Rial left, Rial right)
        {
            return left.Subtract(right);
        }

        public static implicit operator long(Rial rial) => rial.Value;
    }
}
