using GameHub.Application.DTOs;
using GameHub.Domain.Entities;

namespace GameHub.Application.Mapping;

public static class PlatformMapper
{
    public static PlatformDto MapToDto(this Platform platform)
    {
        return new PlatformDto
        {
            Id = platform.Id,
            Name = platform.Name
        };
    }
}