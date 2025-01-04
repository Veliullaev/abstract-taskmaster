using Taskmaster.Application.View.DTO.Tasks;
using Taskmaster.Core;

namespace Taskmaster.Services;

public interface ITaskScheduler
{
    public Task Schedule(CreateTaskDto task);

    public Task<AbstractTaskStatus> GetTaskStatus(Guid taskId);
}