using Taskmaster.Core;
using Taskmaster.Web.Extensions;
using Taskmaster.Web.Startup;

namespace Taskmaster.Web;

public class TaskmasterWebModule : IModule
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddHostedService<StartupTaskRunner>();
        services.AddStartupTasksFromAssembly(typeof(IStartupTask).Assembly);
    }
}