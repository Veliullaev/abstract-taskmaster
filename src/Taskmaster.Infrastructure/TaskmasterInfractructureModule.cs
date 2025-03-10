﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taskmaster.Core;

namespace Taskmaster.Infrastructure;

public class TaskmasterInfractructureModule(TaskmasterConfiguration configuration) : IModule
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddDbContext<TaskmasterDbContext>(config =>
        {
            config.UseNpgsql(configuration.TaskmasterConnectionString?.ConnectionString);
        });
    }
}