using Microsoft.Extensions.DependencyInjection;

namespace Taskmaster.Core;

public interface IModule
{
    void RegisterServices(IServiceCollection services);
}