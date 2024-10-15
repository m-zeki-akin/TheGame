using System.Diagnostics;
using Serilog;

namespace TheGame.Core.Game.Services;

public static class ActionProcessor
{
    public static void Process(Action action)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        try
        {
            action();
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Error occured while processing {action.Method.Name}", e);
        }
        finally
        {
            stopwatch.Stop();
            Log.Information("Process {process} elapsed time: {time}", action.Method.Name, stopwatch.ElapsedMilliseconds);
        }
    }
    
    public static void Process<T>(Action<T> action, T param)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        try
        {
            action(param);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Error occurred while processing {action.Method.Name}", e);
        }
        finally
        {
            stopwatch.Stop();
            Log.Information("Process {process} elapsed time: {time}", action.Method.Name, stopwatch.ElapsedMilliseconds);
        }
    }
}