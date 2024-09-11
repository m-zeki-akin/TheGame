using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheGame.Core.Commands;
using TheGame.Core.Events;
using TheGame.Core.Queries;

namespace TheGame.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;
    private readonly IMediator _mediator;

    public PlayerController(ILogger<PlayerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePlayer([FromBody] CreatePlayerCommand command)
    {
        _logger.LogInformation("Creating player {Username}", command.Username);
        var playerId = await _mediator.Send(command);

        var playerCreatedEvent = new PlayerCreatedEvent(playerId, command.Username, command.Email, DateTime.UtcNow);
        await _mediator.Publish(playerCreatedEvent);

        return CreatedAtAction(nameof(GetPlayerById), new { id = playerId }, playerId);
    }

    [HttpGet]
    public async Task<IActionResult> GetPlayerById(Guid id)
    {
        _logger.LogInformation("Getting player {Id}", id);
        var query = new GetPlayerByIdQuery { Id = id };
        var player = await _mediator.Send(query);

        if (player == null) return NotFound();

        return Ok();
    }
}