﻿

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.DDD;

namespace Shared.Data.Intercepter
{
    public class  DispatchDomainEventsInterceptor(IMediator mediator) :SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            await DispatchDomainEvents(eventData.Context);
            return await base.SavedChangesAsync(eventData, result, cancellationToken);
        }

        private async Task DispatchDomainEvents(DbContext? context)
        {
            if (context == null) return;

            var aggregates = context.ChangeTracker
                            .Entries<IAggregate>()
                            .Where(a => a.Entity.DelayedBorrowEvents.Any())
                            .Select(a => a.Entity);

            var domainEvents = aggregates
                .SelectMany(a=>a.DelayedBorrowEvents)
                .ToList();

            aggregates.ToList().ForEach(a => a.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}
