using Microsoft.EntityFrameworkCore;
using Taskmaster.Infrastructure;

namespace Taskmaster.Web.Startup.Tasks;

public class DatabaseMigrationStartupTask(IServiceScopeFactory factory) : IStartupTask
{
    public async Task Run(CancellationToken ct)
    {
        using var scope = factory.CreateScope();
        var taskmasterContext = scope.ServiceProvider.GetService<TaskmasterDbContext>();
        await taskmasterContext.Database.MigrateAsync(ct);
    }
}