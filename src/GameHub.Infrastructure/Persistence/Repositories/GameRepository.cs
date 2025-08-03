using GameHub.Domain.Entities;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Infrastructure.Persistence.Repositories;

public class GameRepository (AppDbContext context) : IGameRepository
{
    public async Task<Game?> GetByIdAsync(Guid gameId, CancellationToken cancellationToken = default)
    {
        return await context.Games.FirstOrDefaultAsync(game => game.Id == gameId, cancellationToken);
    }
    
    public Task<List<Game>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return context.Games.AsNoTracking().ToListAsync(cancellationToken);
    }
    
    public async Task<List<Game>> GetActiveAsync(CancellationToken cancellationToken = default)
    {
        return await context.Games
            .Where(game => game.IsActive)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    
    public async Task<List<Game>> GetInactiveAsync(CancellationToken cancellationToken = default)
    {
        return await context.Games
            .Where(game => !game.IsActive)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    
    public async Task<List<Game>> GetByAgeRatingAsync(AgeRating ageRating, CancellationToken cancellationToken = default)
    {
        return await context.Games
            .Where(game => game.AgeRating == ageRating)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    
    public async Task<List<Game>> GetByGenreAsync(Genre genre, CancellationToken cancellationToken = default)
    {
        return await context.Games
            .Where(game => game.Genre == genre)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Game>> GetByPlatformAsync(Platform platform, CancellationToken cancellationToken = default)
    {
        return await context.Games
            .Where(game => game.Platform == platform)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Game game, CancellationToken cancellationToken = default)
    {
        await context.Games.AddAsync(game, cancellationToken);
    }

    public void Delete(Game game, CancellationToken cancellationToken = default)
    {
        context.Games.Remove(game);
    }
}