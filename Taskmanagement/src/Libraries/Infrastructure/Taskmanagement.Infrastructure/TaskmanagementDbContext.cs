using Microsoft.EntityFrameworkCore;

namespace Taskmanagement.Infrastructure;
public class TaskmanagementDbContext : DbContext
{
    public TaskmanagementDbContext(DbContextOptions<TaskmanagementDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskmanagementDbContext).Assembly);
    }
}
