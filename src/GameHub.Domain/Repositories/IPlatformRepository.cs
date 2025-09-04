using GameHub.Domain.Entities;

namespace GameHub.Domain.Repositories;

public interface IPlatformRepository
{
    Task <List<Platform>> GetByIdsAsync(List<int> ids, CancellationToken cancellationToken);
    Task<List<Platform>> GetAllAsync(CancellationToken cancellationToken);
    Task<Platform?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Platform platform, CancellationToken cancellationToken);
    void Delete(Platform platform);
}