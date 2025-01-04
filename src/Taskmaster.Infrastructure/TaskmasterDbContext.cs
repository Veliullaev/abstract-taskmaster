using Microsoft.EntityFrameworkCore;
using Taskmaster.Core.Model;

namespace Taskmaster.Infrastructure;

public class TaskmasterDbContext(DbContextOptions<TaskmasterDbContext> contextOptions) : DbContext
{
    public DbSet<AbstractTask> Tasks { get; set; }
}