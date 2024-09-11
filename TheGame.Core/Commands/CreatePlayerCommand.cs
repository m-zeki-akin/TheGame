using MediatR;

namespace TheGame.Core.Commands;

public class CreatePlayerCommand : IRequest<Guid>
{
    public string Username { get; set; }
    public string Email { get; set; }
}