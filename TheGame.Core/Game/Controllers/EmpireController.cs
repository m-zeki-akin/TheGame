using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using TheGame.Core.Game.Commands;
using TheGame.Core.Game.Queries;

namespace TheGame.Core.Game.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpireController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmpireController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePlayer([FromBody] CreateEmpireCommand command)
    {
        Log.Information("Creating player {Username}", command.Player.Username);
        var empireId = await _mediator.Send(command);

        //var playerCreatedEvent = new PlayerCreatedEvent(playerId, command.Username, command.Email, DateTime.UtcNow);
        //await _mediator.Publish(playerCreatedEvent);

       //return CreatedAtAction(nameof(GetPlayerById), new { id = playerId }, playerId);
       return Ok(empireId);
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