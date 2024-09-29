using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace Shared.Data.Intercepter
{
    public class LogEntityInterceptors :SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData evtData, Microsoft.EntityFrameworkCore.Diagnostics.InterceptionResult<int> result)
        {
            UpdateEntities(evtData.Context);
            return base.SavingChanges(evtData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData evtData, Microsoft.EntityFrameworkCore.Diagnostics.InterceptionResult<int> result, CancellationToken cancellationToken= default(CancellationToken))
        {
            UpdateEntities(evtData.Context);
            return base.SavingChangesAsync(evtData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach(var entry in context.ChangeTracker.Entries<IEntity>())
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = "pankaj";
                    entry.Entity.CreatedAt = DateTime.Now;

                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified) {
                    entry.Entity.LastModifiedBy = "Pankaj";
                    entry.Entity.LastModified = DateTime.Now;
                }
            }
        }
    }
}
