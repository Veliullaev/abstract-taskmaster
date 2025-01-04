namespace Taskmaster.Common.Configurations;

[AttributeUsage(AttributeTargets.Class)]
public class ConfigurationAttribute(string key) : Attribute
{
    public string Key { get; set; } = key;
}
