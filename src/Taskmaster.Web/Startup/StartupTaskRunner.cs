using System.Diagnostics;

namespace Taskmaster.Web.Startup;

public class StartupTaskRunner(
    IEnumerable<IStartupTask> startupTasks,
    ILogger<StartupTaskRunner> logger)
    : IHostedService
{
    public async Task StartAsync(CancellationToken ct)
    {
        logger.LogInformation("Startup tasks running");
        var start = Stopwatch.GetTimestamp();

        var groups = startupTasks.GroupBy(x => x.Order)
            .OrderBy(x => x.Key);

        foreach (var @group in groups)
        {
            await Task.WhenAll(group.Select(x => RunTask(x, ct)));
        }

        var elapsedMilliseconds = GetElapsedMilliseconds(start, Stopwatch.GetTimestamp());
        logger.LogInformation("Startup tasks finished in {Elapsed:0.0000} ms", elapsedMilliseconds);
    }

    public Task StopAsync(CancellationToken ct)
    {
        return Task.CompletedTask;
    }

    private async Task RunTask(IStartupTask startupTask, CancellationToken ct)
    {
        logger.LogInformation("{StartupTask} running", startupTask.Name);
        var start = Stopwatch.GetTimestamp();

        try
        {
            await startupTask.Run(ct);

            var elapsedMilliseconds = GetElapsedMilliseconds(start, Stopwatch.GetTimestamp());
            logger.LogInformation("{StartupTask} finished in {Elapsed:0.0000} ms", startupTask.Name, elapsedMilliseconds);
        }
        catch (Exception e)
        {
            logger.LogCritical(e, "{StartupTask} failed", startupTask.Name);
            throw;
        }
    }

    private static double GetElapsedMilliseconds(long start, long stop) => (double)((stop - start) * 1000L) / (double)Stopwatch.Frequency;
}