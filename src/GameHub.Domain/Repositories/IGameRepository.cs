using GameHub.Domain.Entities;
using GameHub.Domain.Enums;

namespace GameHub.Domain.Repositories;

public interface IGameRepository
{
    Task<Game> GetByIdAsync(Guid gameId, CancellationToken cancellationToken = default);
    Task<List<Game>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<Game>> GetActiveAsync(CancellationToken cancellationToken = default);
    Task<List<Game>> GetByGenreAsync(string genre, CancellationToken cancellationToken = default);
    Task<List<Game>> GetByPlatformAsync(string platform, CancellationToken cancellationToken = default);
    Task<List<Game>> GetByAgeRatingAsync(AgeRating ageRating, CancellationToken cancellationToken = default);
    Task AddAsync(Game game, CancellationToken cancellationToken = default);
    Task UpdateAsync(Game game, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid gameId, CancellationToken cancellationToken = default);
}