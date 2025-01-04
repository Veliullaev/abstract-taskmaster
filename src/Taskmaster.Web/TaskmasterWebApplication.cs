using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Serilog;
using Serilog.Events;
using Taskmaster.Common;
using Taskmaster.Core;
using Taskmaster.Infrastructure;
using Taskmaster.Services;
using Aspire.Hosting;

namespace Taskmaster.Web;

public class TaskmasterWebApplication
{
    public void Start(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.File("Logs/log.txt")
            .CreateBootstrapLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddCors(options =>
                {
                    options.AddDefaultPolicy(policy =>
                    {
                        policy
                            .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .AllowAnyHeader();
                    });
                });
            }

            var services = builder.Services;

            var taskmasterConfig = new TaskmasterConfiguration();
            builder.Configuration.Bind(taskmasterConfig);

            services.AddSwaggerGen();

            services.AddModules(
                new TaskmasterInfractructureModule(taskmasterConfig),
                new TaskmasterServicesModule()
                );

            if (taskmasterConfig.IsMessagingServer)
            {
                //var rabbitBuilder = DistributedApplication.CreateBuilder(args);
                //var rabbitmq = rabbitBuilder.AddRabbitMQ("messaging");
            }

            var app = builder.Build();

            var logger = app.Services.GetRequiredService<ILogger<TaskmasterWebApplication>>();

            logger.LogInformation("Starting up...");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            if (!app.Environment.IsProduction())
            {
                app.UseSwagger();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.Run();
        }
        catch (Exception e)
        {
            Log.Fatal(e, "Application start-up failed");
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local"
                || Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                throw;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}