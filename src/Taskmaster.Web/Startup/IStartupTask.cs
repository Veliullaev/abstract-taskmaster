namespace Taskmaster.Web.Startup;

public interface IStartupTask
{
    string Name => GetType().Name;
    int Order => 0;
    Task Run(CancellationToken ct);
}