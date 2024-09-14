using MediatR;

namespace TheGame.Core.Commands;

public class CreatePlayerCommand : IRequest<long>
{
    public string Username { get; set; }
    public string Email { get; set; }
}