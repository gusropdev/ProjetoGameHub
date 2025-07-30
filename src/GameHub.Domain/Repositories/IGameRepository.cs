using GameHub.Domain.Entities;
using GameHub.Domain.Enums;

namespace GameHub.Domain.Repositories;

public interface IGameRepository
{
    Task<Game> GetGameByIdAsync(Guid gameId, CancellationToken cancellationToken = default);
    Task<List<Game>> GetAllGamesAsync(CancellationToken cancellationToken = default);
    Task<List<Game>> GetActiveGamesAsync(CancellationToken cancellationToken = default);
    Task<List<Game>> GetGamesByGenreAsync(string genre, CancellationToken cancellationToken = default);
    Task<List<Game>> GetGamesByPlatformAsync(string platform, CancellationToken cancellationToken = default);
    Task<List<Game>> GetGamesByAgeRatingAsync(AgeRating ageRating, CancellationToken cancellationToken = default);
    Task AddGameAsync(Game game, CancellationToken cancellationToken = default);
    Task UpdateGameAsync(Game game, CancellationToken cancellationToken = default);
    Task DeleteGameAsync(Guid gameId, CancellationToken cancellationToken = default);
}