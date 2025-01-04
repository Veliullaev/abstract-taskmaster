using System.Reflection;
using Taskmaster.Web.Startup;

namespace Taskmaster.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddStartupTasksFromAssembly(this IServiceCollection self, Assembly assembly)
    {
        var interfaceType = typeof(IStartupTask);
        var implementationTypes = assembly.GetTypes()
            .Where(x => x.GetInterfaces().Contains(interfaceType))
            .Where(x => !x.IsAbstract)
            .ToList();
        implementationTypes.ForEach(x => self.AddSingleton(interfaceType, x));
    }
}