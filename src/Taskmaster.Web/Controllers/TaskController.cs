using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskmaster.Application.View.DTO.Tasks;

namespace Taskmaster.Web.Controllers;

[Authorize]
[ApiController]
[Route("api/tasks/[action]")]
public class TaskController(ILogger<TaskController> logger) : ControllerBase
{
    [HttpGet]
    public async Task TaskInformation(Guid taskId, CancellationToken ct = default)
    {
        logger.LogInformation("Retrieving information about {taskId}...", taskId);
    }

    [HttpPost]
    public async Task Create(CreateTaskDto dto, CancellationToken ct = default)
    {
        logger.LogInformation("Creating and assigning task...");
    } 
}