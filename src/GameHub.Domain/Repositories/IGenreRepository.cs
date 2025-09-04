using GameHub.Domain.Entities;

namespace GameHub.Domain.Repositories;

public interface IGenreRepository
{
    Task<List<Genre>> GetByIdsAsync(List<int> ids, CancellationToken cancellationToken);
    Task<List<Genre>> GetAllAsync(CancellationToken cancellationToken);
    Task<Genre?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Genre genre, CancellationToken cancellationToken);
    void Delete(Genre genre);
}