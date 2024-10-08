using Force.DeepCloner;
using Microsoft.Extensions.Hosting;
using Serilog;
using TheGame.Core.Game.Cache;
using TheGame.Core.Game.Data;

namespace TheGame.Core.Game.Services;

public interface ISnapshotService
{
    public Task SaveSnapshotAsync();
    
    public Task WaitForSnapshotToCompleteAsync();
    
}