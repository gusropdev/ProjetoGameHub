using GameHub.Domain.Entities;

namespace GameHub.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}