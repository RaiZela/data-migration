namespace BuildingBlocks.Intefaces;

public interface ICurrentUserService
{
    public string? Username { get; }
    public string? Email { get; }
}

