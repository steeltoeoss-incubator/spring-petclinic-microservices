using System.Linq;
using System.Threading;

namespace Petclinic.Visits.Infrastructure
{
    public static class SeedData
    {
        public static async void SeedAll(this VisitsContext dbContext, bool ensureDelete = false, bool ensureCreated = false, CancellationToken cancellationToken = default)
        {
            if (ensureDelete)
            {
                dbContext.Database.EnsureDeleted();
            }

            if (ensureCreated)
            {
                dbContext.Database.EnsureCreated();
            }

            if (!dbContext.Visits.Any())
            {
                foreach (var visit in Fill.Visits)
                {
                    await dbContext.AddAsync(visit, cancellationToken);
                }
            }

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
