using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Entities
{
    public abstract class BaseAggregateRoot<TId>: IEquatable<TId>
    {
        private readonly List<IEvents> _events;
        public TId Id { get; protected set; }
        protected BaseAggregateRoot() => _events = new(0);
        protected void HandleEvent(IEvents @event)
        {
            SetStateByEvent(@event);
            ValidateInvariants();
            _events.Add(@event);
        }
        protected abstract void SetStateByEvent(IEvents @event);
        protected abstract void ValidateInvariants();
        public IEnumerable<object> GetEvents() => _events.AsEnumerable();
        public void ClearEvents() => _events.Clear();
        public override bool Equals(object obj)
        {
            var other = obj as BaseAggregateRoot<TId>;
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(other, this))
                return true;
            if (GetType() != other.GetType())
                return false;
            //if (Id == default || other.Id == default)
            //    return false;

            return Id.Equals(other.Id);
        }
        public static bool operator ==(BaseAggregateRoot<TId> a, BaseAggregateRoot<TId> b)
        {
            if (ReferenceEquals(a,null) && ReferenceEquals(b,null))
            {
                return true;
            }
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }
            return a.Equals(b);
        }
        public static bool operator !=(BaseAggregateRoot<TId> a, BaseAggregateRoot<TId> b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public bool Equals(TId? other)
        {
            return this.Id.Equals(other);
        }
    }
}
