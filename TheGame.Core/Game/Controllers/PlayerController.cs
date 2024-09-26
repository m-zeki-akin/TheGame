using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using TheGame.Core.Game.Commands;
using TheGame.Core.Game.Queries;

namespace TheGame.Core.Game.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlayerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePlayer([FromBody] CreatePlayerCommand command)
    {
        Log.Information("Creating player {Username}", command.Username);
        var playerId = await _mediator.Send(command);

        //var playerCreatedEvent = new PlayerCreatedEvent(playerId, command.Username, command.Email, DateTime.UtcNow);
        //await _mediator.Publish(playerCreatedEvent);

        return CreatedAtAction(nameof(GetPlayerById), new { id = playerId }, playerId);
    }

    [HttpGet]
    public async Task<IActionResult> GetPlayerById(Guid id)
    {
        Log.Information("Getting player {Id}", id);
        var query = new GetPlayerByIdQuery { Id = id };
        var player = await _mediator.Send(query);

        if (player == null)
        {
            return NotFound();
        }

        return Ok();
    }
}