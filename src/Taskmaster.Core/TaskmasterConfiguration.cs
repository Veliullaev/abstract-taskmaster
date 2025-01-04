namespace Taskmaster.Core;

public class TaskmasterConfiguration
{
    public class ConnectionStringEntry
    {
        public string ConnectionString { get; set; }
    }

    public bool IsMessagingServer { get; set; }

    public IReadOnlyDictionary<string, ConnectionStringEntry> ConnectionStrings { get; set; } = new Dictionary<string, ConnectionStringEntry>();

    public ConnectionStringEntry? TaskmasterConnectionString => ConnectionStrings?.GetValueOrDefault("Taskmaster");

}