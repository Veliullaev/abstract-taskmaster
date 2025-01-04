using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskmaster.Core.Model;

namespace Taskmaster.Infrastructure.Configurations;

public class AbstractTaskEntityTypeConfiguration : IEntityTypeConfiguration<AbstractTask>
{
    public void Configure(EntityTypeBuilder<AbstractTask> builder)
    {
        builder.HasKey(x => x.Id);
    }
}