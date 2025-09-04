using GameHub.Domain.Entities;
using GameHub.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Infrastructure.Persistence.Repositories;

public class PlatformRepository (AppDbContext context) : IPlatformRepository
{
    public async Task<List<Platform>> GetByIdsAsync(List<int> ids, CancellationToken cancellationToken)
    {
        return await context.Platforms
            .Where(g => ids.Contains(g.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Platform>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Platforms
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Platform?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Platforms
            .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }

    public async Task AddAsync(Platform platform, CancellationToken cancellationToken)
    {
        await context.Platforms
            .AddAsync(platform, cancellationToken);
    }

    public void Delete(Platform platform)
    {
        context.Platforms
            .Remove(platform);
    }
}