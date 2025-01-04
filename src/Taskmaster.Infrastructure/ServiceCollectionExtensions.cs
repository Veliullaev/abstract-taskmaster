using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Taskmaster.Common.Configurations;

namespace Taskmaster.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static TConfig AddConfiguration<TConfig>(this IServiceCollection self, IConfiguration configuration)
        where TConfig : class, ICustomConfiguration, new()
    {
        var key = GetKey(typeof(TConfig));

        self.AddOptions<TConfig>().Bind(configuration.GetSection(key));
        self.AddSingleton(x => x.GetRequiredService<IOptions<TConfig>>().Value);

        var config = new TConfig();
        configuration.Bind(key, config);

        return config;
    }

    public static TConfig GetCustomConfig<TConfig>(this IConfiguration config)
        where TConfig : ICustomConfiguration, new()
    {
        var customConfig = new TConfig();
        config.Bind(GetKey(typeof(TConfig)), customConfig);
        return customConfig;
    }

    private static string GetKey(Type configType)
    {
        var attributes = configType.GetCustomAttributes(typeof(ConfigurationAttribute), true);
        var key = attributes.Length > 0
            ? (attributes.First() as ConfigurationAttribute)?.Key
            : configType.Name.Replace("Configuration", "");
        return key;
    }
}