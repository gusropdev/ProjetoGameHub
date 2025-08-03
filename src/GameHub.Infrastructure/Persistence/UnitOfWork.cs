using GameHub.Domain.Repositories;

namespace GameHub.Infrastructure.Persistence;

public class UnitOfWork (AppDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}