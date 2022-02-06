using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Entities
{
    public abstract class BaseEntity<TId> where TId : IEquatable<TId>
    {
        public TId Id { get; protected set; }

        private Action<IEvents> _applier;

        public BaseEntity(Action<IEvents> applier)
        {
            _applier = applier;
        }
        public BaseEntity()
        {
        }

        public void HandleEvent(IEvents @event)
        {
            SetStateByEvent(@event);
            _applier(@event);
        }
        protected abstract void SetStateByEvent(IEvents @event);

        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity<TId>;
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
        public static bool operator ==(BaseEntity<TId> a, BaseEntity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }
            return a.Equals(b);
        }
        public static bool operator !=(BaseEntity<TId> a, BaseEntity<TId> b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }

    //public abstract class BaseEntity<TId>
    //{
    //    private readonly List<IEvents> _events = new(0);
    //    public IEnumerable<IEvents> GetChangess() => _events.AsEnumerable();
    //    public void ClearChanges() => _events.Clear();
    //    private void Raise(IEvents @event) => _events.Add(@event);
    //    protected void HandleEvent(IEvents @event)
    //    {
    //        SetStateByEvent(@event);
    //        ValidateInvariants();
    //        Raise(@event);
    //    }

    //    public TId Id { get; set; }
    //    protected abstract void ValidateInvariants();
    //    protected abstract void SetStateByEvent(IEvents @event);

    //}
}
