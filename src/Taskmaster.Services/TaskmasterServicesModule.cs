using Microsoft.Extensions.DependencyInjection;
using Taskmaster.Core;

namespace Taskmaster.Services;

public class TaskmasterServicesModule : IModule
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<ITaskScheduler, TaskScheduler>();
    }
}