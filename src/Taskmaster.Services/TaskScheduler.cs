using Microsoft.Extensions.Logging;
using Taskmaster.Application.View.DTO.Tasks;
using Taskmaster.Core;
using Taskmaster.Core.Model;

namespace Taskmaster.Services;

public class TaskScheduler(ILogger<TaskScheduler> logger) : ITaskScheduler
{
    public Queue<AbstractTask> Tasks { get; set; } = new Queue<AbstractTask>();

    /// <summary>
    /// Добавляет таск в БД и отправляет его на поду.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task Schedule(CreateTaskDto task)
    {
        var id = Guid.NewGuid();
        var startTime = DateTime.Now;

        logger.LogInformation("Scheduling task {id} ...", id);

        throw new NotImplementedException();
    }

    public async Task<AbstractTaskStatus> GetTaskStatus(Guid taskId)
    {
        throw new NotImplementedException();
    }
}