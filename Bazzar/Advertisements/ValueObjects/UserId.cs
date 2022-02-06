using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Domain.Advertisements.ValueObjects
{
    public class UserId : BaseValueObject<UserId>
    {
        public Guid Value { get; private set; }
        public static UserId FromString(string value) => new UserId(Guid.Parse(value));
        public UserId(Guid value)
        {
            if (value == default)
            {
                throw new ArgumentException("شناسه نمی تواند خالی باشد");
            }

            Value = value;
        }

        public override int ObjectGetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool ObjectIsEqual(UserId otherObject)
        {
            return Value == otherObject.Value;
        }

        public static implicit operator Guid(UserId userId) => userId.Value;
    }
}
