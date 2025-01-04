using Microsoft.EntityFrameworkCore;
using Taskmaster.Core.Model;

namespace Taskmaster.Infrastructure;

public class TaskmasterDbContext : DbContext
{
    public DbSet<AbstractTask> Tasks { get; set; }

    public TaskmasterDbContext() { }

    public TaskmasterDbContext(DbContextOptions<TaskmasterDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskmasterDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}