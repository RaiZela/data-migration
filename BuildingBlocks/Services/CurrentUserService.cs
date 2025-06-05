using BuildingBlocks.Intefaces;
using Microsoft.AspNetCore.Http;

namespace clients_application.Data.Services;

public class CurrentUserService : ICurrentUserService
{
    public string? Username { get; }
    public string? Role { get; }
    public string? Email { get; }

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {

    }
}
