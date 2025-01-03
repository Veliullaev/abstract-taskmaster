namespace Taskmaster.Application.View.DTO.Tasks;

public class CreateTaskDto : ViewDto
{
    public string Description { get; set; }
    public long Ttl { get; set; }
    public byte[] Data { get; set; }
}