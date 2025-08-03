using GameHub.Domain.Entities;
using GameHub.Domain.Enums;

namespace GameHub.Domain.Repositories;

public interface IGameRepository
{
    Task<Game?> GetByIdAsync(Guid gameId, CancellationToken cancellationToken = default);
    Task<List<Game>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<Game>> GetActiveAsync(CancellationToken cancellationToken = default);
    Task<List<Game>> GetInactiveAsync(CancellationToken cancellationToken = default);
    Task<List<Game>> GetByAgeRatingAsync(AgeRating ageRating, CancellationToken cancellationToken = default);
    Task<List<Game>> GetByGenreAsync(Genre genre, CancellationToken cancellationToken = default);
    Task<List<Game>> GetByPlatformAsync(Platform platform, CancellationToken cancellationToken = default);
    Task AddAsync(Game game, CancellationToken cancellationToken = default);
    void Delete(Game game, CancellationToken cancellationToken = default);
}