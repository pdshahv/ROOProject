using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DDD
{
    public abstract class Aggregate<TId> : Entity<TId> , IAggregate<TId>
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        //private readonly List<IDomainEvent> _createEvents = new();
        //private readonly List<IDomainEvent> _borrowEvents = new();
       // private readonly List<IDomainEvent> _delayedborrowEvents = new();

        //public IReadOnlyList<IDomainEvent> createEvents => _createEvents.AsReadOnly();
        //public IReadOnlyList<IDomainEvent> borrowEvents => _borrowEvents.AsReadOnly();

        //public IReadOnlyList<IDomainEvent> delayedBorrowEvents => _borrowEvents.AsReadOnly();

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        //public void DeplayedBorrowEvent(IDomainEvent borrowEvent)
        //{
        //    _delayedborrowEvents.Add(borrowEvent);
        //}
        //public void AddBorrowEvent(IDomainEvent borrowEvent)
        //{
        //    _borrowEvents.Add(borrowEvent);
        //}

        //public void AddCreateEvent(IDomainEvent createEvent)
        //{
        //    _createEvents.Add(createEvent);
        //}
        public void AddDomainEvent(IDomainEvent domainEvents)
        {
            _domainEvents.Add(domainEvents);
        }


        public IDomainEvent[] ClearBorrowEvents()
        {
            IDomainEvent[] dequeuedEvents = _domainEvents.ToArray();
            _domainEvents.Clear();
            return dequeuedEvents;
        }

        public IDomainEvent[] ClearDomainEvents()
        {
            throw new NotImplementedException();
        }
    }
}
