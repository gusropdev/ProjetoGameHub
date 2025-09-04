using GameHub.Application.DTOs;
using GameHub.Domain.Entities;

namespace GameHub.Application.Mapping;

public static class GenreMapper
{
    public static GenreDto MapToDto(this Genre genre)
    {
        return new GenreDto
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }
}