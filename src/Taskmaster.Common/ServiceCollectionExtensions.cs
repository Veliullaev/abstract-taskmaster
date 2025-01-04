using Microsoft.Extensions.DependencyInjection;
using Taskmaster.Core;
using System.Linq;

namespace Taskmaster.Common;

public static class ServiceCollectionExtensions
{
    public static void AddModule(this IServiceCollection self, IModule module)
    {
        module.RegisterServices(self);
    }

    public static void AddModules(this IServiceCollection self, params IModule[] modules)
    {
        foreach (var module in modules)
        {
            self.AddModule(module);
        }
    }
}