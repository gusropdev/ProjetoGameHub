using GameHub.Domain.Entities;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Infrastructure.Persistence.Repositories;

public class GameRepository (AppDbContext context) : IGameRepository
{
    public async Task<Game?> GetByIdAsync(Guid gameId, CancellationToken cancellationToken = default)
    {
        return await context
            .Games
            .Include(game =>  game.Genres)
            .Include(game => game.Platforms)
            .FirstOrDefaultAsync(game => game.Id == gameId, cancellationToken);
    }
    
    public Task<List<Game>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return context.Games
            .AsNoTracking()
            .Include(game =>  game.Genres)
            .Include(game => game.Platforms)
            .ToListAsync(cancellationToken);
    }
    
    public async Task<List<Game>> GetActiveAsync(CancellationToken cancellationToken = default)
    {
        return await context.Games
            .Where(game => game.IsActive)
            .Include(game =>  game.Genres)
            .Include(game => game.Platforms)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    
    public async Task<List<Game>> GetInactiveAsync(CancellationToken cancellationToken = default)
    {
        return await context.Games
            .Where(game => !game.IsActive)
            .Include(game =>  game.Genres)
            .Include(game => game.Platforms)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    
    public async Task<List<Game>> GetByAgeRatingAsync(AgeRating ageRating, CancellationToken cancellationToken = default)
    {
        return await context.Games
            .Where(game => game.AgeRating == ageRating)
            .Include(game =>  game.Genres)
            .Include(game => game.Platforms)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    
    public async Task<List<Game>> GetByGenreAsync(int genreId, CancellationToken cancellationToken = default)
    {
        return await context.Games
            .Where(game => game.Genres.Any(genre => genre.Id == genreId))
            .Include(game =>  game.Genres)
            .Include(game => game.Platforms)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Game>> GetByPlatformAsync(int platformId, CancellationToken cancellationToken = default)
    {   
        return await context.Games
            .Where(game => game.Platforms.Any(platform => platform.Id == platformId))
            .Include(game  => game.Platforms)
            .Include(game =>  game.Genres)
            .Include(game => game.Platforms)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Game game, CancellationToken cancellationToken = default)
    {
        await context
            .Games
            .AddAsync(game, cancellationToken);
    }

    public void Delete(Game game, CancellationToken cancellationToken = default)
    {
        context
            .Games
            .Remove(game);
    }
}