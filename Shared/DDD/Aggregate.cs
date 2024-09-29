using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DDD
{
    public abstract class Aggregate<TId> : Entity<TId> , IAggregate<TId>
    {
        private readonly List<IDomainEvent> _borrowEvents = new();
        private readonly List<IDomainEvent> _delayedborrowEvents = new();
        public IReadOnlyList<IDomainEvent> borrowEvents => _borrowEvents.AsReadOnly();

        public IReadOnlyList<IDomainEvent> DelayedBorrowEvents => _borrowEvents.AsReadOnly();

        public void DeplayedBorrowEvent(IDomainEvent borrowEvent)
        {
            _delayedborrowEvents.Add(borrowEvent);
        }
        public void AddBorrowEvent(IDomainEvent borrowEvent)
        {
            _borrowEvents.Add(borrowEvent);
        }

        public IDomainEvent[] ClearBorrowEvents()
        {
            IDomainEvent[] dequeuedEvents = _borrowEvents.ToArray();
            _borrowEvents.Clear();
            return dequeuedEvents;
        }

        public IDomainEvent[] ClearDomainEvents()
        {
            throw new NotImplementedException();
        }
    }
}
