using GameHub.Domain.Entities;
using GameHub.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Infrastructure.Persistence.Repositories;

public class GenreRepository (AppDbContext context): IGenreRepository
{
    public async Task<List<Genre>> GetByIdsAsync(List<int> ids, CancellationToken cancellationToken)
    {
        return await context.Genres
            .Where(g => ids.Contains(g.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Genre>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Genres
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Genre?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Genres
            .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }

    public async Task AddAsync(Genre genre, CancellationToken cancellationToken)
    {
         await context.Genres
            .AddAsync(genre, cancellationToken);
    }

    public void Delete(Genre genre)
    {
        context.Genres
            .Remove(genre);
    }
}