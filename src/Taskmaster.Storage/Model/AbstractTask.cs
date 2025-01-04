namespace Taskmaster.Storage.Model;

public class AbstractTask : Record
{
    public long Ttl { get; set; }
    public string Description { get; set; }
}